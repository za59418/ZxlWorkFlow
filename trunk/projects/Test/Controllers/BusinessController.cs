using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DCIIDS.Data;
using Test.Model;
using Test.ModelView;

namespace Test.Controllers
{
    public class BusinessController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project(int ProjectId)
        {
            SYS_PROJECT model = new SYS_PROJECT();
            model.id = ProjectId;

            return View(ProjectId);
        }

        public ActionResult ProjectForm(int ProjectId)
        {
            return View(ProjectId);
        }

        public ActionResult GetForms(int ProjectId)
        {
            List<SYS_PROJECTFORM> list = null;
            using (ORMHandler orm = DCIIDS.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECTFORM>("where ref_project_id='" + ProjectId + "'");
            }
            SYS_PROJECTFORM root = null;
            if (null != list && list.Count > 0)
            {
                root = new SYS_PROJECTFORM();
                root.children = new List<AbstractModel>();
                root.id = 1;
                root.pid = 0;
                root.text = "表单列表";

                foreach (SYS_PROJECTFORM form in list)
                {
                    form.id = form.ID;
                    form.pid = 1;
                    form.text = form.FORMNAME;
                    root.children.Add(form);
                }
            }

            List<SYS_PROJECTFORM> result = new List<SYS_PROJECTFORM>();
            result.Add(root);

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }


        public ActionResult ProjectMaterial(int ProjectId)
        {
            return View(ProjectId);
        }

        public ActionResult GetMaterials(int ProjectId)
        {

            List<SYS_BUSINESSMATERIAL> result = null;
            List<SYS_PROJECTMATERIAL> projectMaterials = null;
            using (ORMHandler orm = DCIIDS.Data.DatabaseManager.ORMHandler)
            {
                SYS_PROJECT prj = orm.Init<SYS_PROJECT>("where id='" + ProjectId + "'");

                result = orm.Query<SYS_BUSINESSMATERIAL>("where ref_business_id='" + prj.REF_BUSINESS_ID + "'");

                projectMaterials = orm.Query<SYS_PROJECTMATERIAL>("where ref_project_id='" + ProjectId + "'");
            }

            foreach (SYS_BUSINESSMATERIAL tem in result)
            {
                tem.id = tem.ID;
                tem.pid = 0;
                tem.text = tem.MATERIALNAME;

                tem.children = new List<AbstractModel>();
                foreach (SYS_PROJECTMATERIAL projectMaterial in projectMaterials)
                {
                    if(tem.id == projectMaterial.REF_BUSINESSMATERIAL_ID)
                    {
                        projectMaterial.id = projectMaterial.ID + 10;
                        projectMaterial.pid = tem.id;
                        projectMaterial.text = projectMaterial.MATERIALNAME;

                        tem.children.Add(projectMaterial);
                    }
                }
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }

        public ActionResult Dialog_SendUser(int ProjectId)
        {
            return View("Dialog/Dialog_SendUser", ProjectId);
        }
        public ActionResult SendUserTree(int ProjectId)
        {
            SYS_PROJECTACTIVITY projectActivity = null;
            SYS_BUSINESSACTIVITY businessActivity = null;
            List<SYS_BUSINESSROLE> businessRoles = null;
            List<SYS_BUSINESSROLEUSER> businessRoleUsers = null;
            using (ORMHandler orm = DCIIDS.Data.DatabaseManager.ORMHandler)
            {
                projectActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id='" + ProjectId + "' and state=0");
                businessActivity = orm.Init<SYS_BUSINESSACTIVITY>("where id=" + projectActivity.REF_BUSINESSACTIVITY_ID);
                businessRoles = orm.Query<SYS_BUSINESSROLE>("where id=" + businessActivity.REF_BUSINESSROLE_ID);
                foreach (SYS_BUSINESSROLE role in businessRoles)
                {
                    role.text = role.ROLENAME;
                    role.id = role.ID;
                    role.pid = 0;
                    role.iconCls = "icon-users";
                    role.children = new List<AbstractModel>();
                    businessRoleUsers = orm.Query<SYS_BUSINESSROLEUSER>("where ref_businessrole_id=" + role.ID);

                    foreach (SYS_BUSINESSROLEUSER u in businessRoleUsers)
                    {
                        SYS_USER user = orm.Init<SYS_USER>("where id=" + u.REF_USER_ID);
                        user.text = user.USERNAME;
                        user.id = user.ID;
                        user.pid = businessActivity.id;
                        user.iconCls = "icon-user-suit-black";
                        role.children.Add(user);
                    }
                }
                orm.Close();
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(businessRoles));
            System.Web.HttpContext.Current.Response.End();
            return Json(businessRoles);
        }
        public ActionResult DoSend(int ProjectId,int RecvUserId)
        {
            ServiceResult result = new ServiceResult();
            SYS_PROJECTACTIVITY currActivity = null;
            try
            {
                using (ORMHandler orm = DCIIDS.Data.DatabaseManager.ORMHandler)
                {
                    currActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id='" + ProjectId + "' and state=0");
                    currActivity.ENDTIME = DateTime.Now;
                    currActivity.STATE = 1;
                    orm.Save(currActivity);

                    SYS_PROJECTACTIVITY nextActivity = new SYS_PROJECTACTIVITY();
                    nextActivity.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITY");
                    nextActivity.REF_PROJECTPROCESS_ID = currActivity.REF_PROJECTPROCESS_ID;
                    nextActivity.REF_BUSINESSACTIVITY_ID = orm.Init<SYS_BUSINESSACTIVITYROUTE>("REF_FROM_BUSINESSACTIVITY_ID=" + currActivity.ID).REF_TO_BUSINESSACTIVITY_ID;
                    nextActivity.REF_USER_ID = RecvUserId;
                    nextActivity.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                    nextActivity.STARTTIME = DateTime.Now;
                    nextActivity.STATE = 0;
                    orm.Insert(nextActivity);

                    orm.Close();
                    result.ReturnCode = ServiceResultCode.Success;
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Error;
                result.Message = e.Message;
            }
            return Json(result);
        }

    }
}
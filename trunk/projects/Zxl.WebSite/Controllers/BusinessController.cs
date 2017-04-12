using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Zxl.Data;
using Zxl.WebSite.Model;
using Zxl.WebSite.ModelView;

namespace Zxl.WebSite.Controllers
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
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
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
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
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
                    if (tem.id == projectMaterial.REF_BUSINESSMATERIAL_ID)
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

        public ActionResult Dialog_Business()
        {
            return View("Dialog/Dialog_Business");
        }

        public ActionResult BusinessTree()
        {
            List<SYS_BUSINESS> businesses = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                businesses = orm.Query<SYS_BUSINESS>();
                orm.Close();
            }

            SYS_BUSINESS root = null;
            if (null != businesses && businesses.Count > 0)
            {
                root = new SYS_BUSINESS();
                root.children = new List<AbstractModel>();
                root.id = 1;
                root.pid = 0;
                root.text = "业务列表";

                foreach (SYS_BUSINESS business in businesses)
                {
                    business.id = business.ID;
                    business.pid = 1;
                    business.text = business.BUSINESSNAME;
                    root.children.Add(business);
                }
            }

            List<SYS_BUSINESS> result = new List<SYS_BUSINESS>();
            result.Add(root);

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(result));
            System.Web.HttpContext.Current.Response.End();
            return Json(result);
        }

        public ActionResult SendUserTree(int ProjectId)
        {
            SYS_PROJECTACTIVITY currProjActivity = null;
            SYS_BUSINESSACTIVITY nextBusinessActivity = null;
            List<SYS_BUSINESSROLE> businessRoles = null;
            List<SYS_BUSINESSROLEUSER> businessRoleUsers = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                currProjActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and state=0");
                int nextBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_FROM_BUSINESSACTIVITY_ID=" + currProjActivity.REF_BUSINESSACTIVITY_ID).REF_TO_BUSINESSACTIVITY_ID;
                nextBusinessActivity = orm.Init<SYS_BUSINESSACTIVITY>("where id=" + nextBusinessActivityId);
                businessRoles = orm.Query<SYS_BUSINESSROLE>("where id=" + nextBusinessActivity.REF_BUSINESSROLE_ID);
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
                        user.pid = nextBusinessActivity.id;
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
        public ActionResult DoSend(int ProjectId, string RecvUserId)
        {
            ServiceResult result = new ServiceResult();
            SYS_PROJECTACTIVITY currActivity = null;
            SYS_PROJECTWORKITEM currWorkitem = null;

            try
            {
                string[] userIds = RecvUserId.Split(',');
                if (null == RecvUserId || "" == RecvUserId || userIds.Length == 0)
                {
                    result.ReturnCode = ServiceResultCode.Error;
                    result.Message = "没有接收人员！";
                }
                else
                {
                    using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                    {
                        currActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and state=0");
                        currWorkitem = orm.Init<SYS_PROJECTWORKITEM>("where ref_project_id=" + ProjectId + " and state=0");

                        //插入新记录
                        int nextBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_FROM_BUSINESSACTIVITY_ID=" + currActivity.REF_BUSINESSACTIVITY_ID).REF_TO_BUSINESSACTIVITY_ID;
                        SYS_PROJECTACTIVITY nextActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id=" + ProjectId + " and REF_BUSINESSACTIVITY_ID=" + nextBusinessActivityId);

                        if (null == nextActivity) // 不重复创建，只改状态
                        {
                            nextActivity = new SYS_PROJECTACTIVITY();
                            nextActivity.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITY");
                            nextActivity.REF_PROJECTPROCESS_ID = currActivity.REF_PROJECTPROCESS_ID;
                            nextActivity.REF_BUSINESSACTIVITY_ID = nextBusinessActivityId;
                            nextActivity.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                            nextActivity.STATE = 0;
                            orm.Insert(nextActivity);
                        }
                        foreach (string userId in userIds)
                        {
                            //保存新的工作项
                            SYS_PROJECTWORKITEM nextWorkitem = new SYS_PROJECTWORKITEM();
                            nextWorkitem.ID = ValueOperator.CreatePk("SYS_PROJECTWORKITEM");
                            nextWorkitem.REF_PROJECTACTIVITY_ID = nextActivity.ID;
                            nextWorkitem.REF_USER_ID = Convert.ToInt32(userId);
                            nextWorkitem.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                            nextWorkitem.STARTTIME = DateTime.Now;
                            nextWorkitem.STATE = 0;
                            orm.Insert(nextWorkitem);

                            //保存路由
                            SYS_PROJECTACTIVITYROUTE route = new SYS_PROJECTACTIVITYROUTE();
                            route.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITYROUTE");
                            route.REF_FROM_PROACT_ID = currActivity.ID;
                            route.REF_TO_PROACT_ID = nextActivity.ID;
                            route.ROUTETYPE = 0; // 发送
                            orm.Insert(route);
                        }

                        //更新旧记录
                        currActivity.STATE = 1;
                        orm.Save(currActivity);
                        //更新新记录
                        nextActivity.STATE = 0;
                        orm.Save(nextActivity);
                        //更新旧工作项
                        currWorkitem.STATE = 1;
                        currWorkitem.ENDTIME = DateTime.Now;
                        orm.Save(currWorkitem);

                        orm.Close();
                        result.ReturnCode = ServiceResultCode.Success;
                    }
                }
            }
            catch (Exception e)
            {
                result.ReturnCode = ServiceResultCode.Error;
                result.Message = e.Message;
            }
            return Json(result);
        }
        public ActionResult DoBack(int ProjectId)
        {
            ServiceResult result = new ServiceResult();
            SYS_PROJECTACTIVITY currActivity = null;
            SYS_PROJECTACTIVITY lastActivity = null;
            SYS_PROJECTWORKITEM currWorkitem = null;

            try
            {
                using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
                {
                    currActivity = orm.Init<SYS_PROJECTACTIVITY>("where ref_project_id='" + ProjectId + "' and state=0");
                    currWorkitem = orm.Init<SYS_PROJECTWORKITEM>("where ref_project_id=" + ProjectId + " and state=0");
                    int lastBusinessActivityId = orm.Init<SYS_BUSINESSACTIVITYROUTE>("where REF_TO_BUSINESSACTIVITY_ID=" + currActivity.REF_BUSINESSACTIVITY_ID).REF_FROM_BUSINESSACTIVITY_ID;
                    lastActivity = orm.Init<SYS_PROJECTACTIVITY>("where REF_BUSINESSACTIVITY_ID=" + lastBusinessActivityId);

                    //回退也要保存新的工作项
                    SYS_PROJECTWORKITEM nextWorkitem = new SYS_PROJECTWORKITEM();
                    nextWorkitem.ID = ValueOperator.CreatePk("SYS_PROJECTWORKITEM");
                    nextWorkitem.REF_PROJECTACTIVITY_ID = lastActivity.ID;
                    nextWorkitem.REF_USER_ID = orm.Init<SYS_PROJECTWORKITEM>("where REF_PROJECTACTIVITY_ID=" + lastActivity.ID + " order by id desc").REF_USER_ID;//找最后一条USERID
                    nextWorkitem.REF_PROJECT_ID = currActivity.REF_PROJECT_ID;
                    nextWorkitem.STARTTIME = DateTime.Now;
                    nextWorkitem.STATE = 0;
                    orm.Insert(nextWorkitem);

                    //保存路由
                    SYS_PROJECTACTIVITYROUTE route = new SYS_PROJECTACTIVITYROUTE();
                    route.ID = ValueOperator.CreatePk("SYS_PROJECTACTIVITYROUTE");
                    route.REF_FROM_PROACT_ID = currActivity.ID;
                    route.REF_TO_PROACT_ID = lastActivity.ID;
                    route.ROUTETYPE = Convert.ToInt32(PROJECTACTIVITYROUTE.BACK); // 回退
                    orm.Insert(route);

                    //更新新环节记录
                    lastActivity.STATE = 0;
                    orm.Save(lastActivity);
                    //更新旧环节记录
                    currActivity.STATE = 1;
                    orm.Save(currActivity);
                    //更新旧工作项
                    currWorkitem.STATE = 1;
                    currWorkitem.ENDTIME = DateTime.Now;
                    orm.Save(currWorkitem);

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
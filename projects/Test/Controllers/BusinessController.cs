using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DCIIDS.Data;
using Test.Model;

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
    }
}
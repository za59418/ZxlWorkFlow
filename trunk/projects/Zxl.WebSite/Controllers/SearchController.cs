using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using Zxl.Data;
using Zxl.Business.Model;
using Zxl.WebSite.ModelView;
using Zxl.Printer;
using Zxl.Form.Sheet;

namespace Zxl.WebSite.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(SearchViewModel model)
        {
            return PartialView(model);
        }

        public ActionResult Processing(SearchViewModel model)
        {
            return PartialView(model);
        }
        public ActionResult Finished(SearchViewModel model)
        {
            return PartialView(model);
        }

        public ActionResult Projectsing(SearchViewModel model)
        {
            List<SYS_PROJECT> list = null;
            string UserId = Session["UserId"].ToString();
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                string whereClause = " where 1=1 ";
                whereClause += " and ID in (select ref_project_id from sys_projectworkitem where state=0) ";
                if (null != model.PROJECTNO)
                    whereClause += " and PROJECTNO like '%" + model.PROJECTNO + "%' ";
                if (null != model.PROJECTNAME)
                    whereClause += " and PROJECTNAME like '%" + model.PROJECTNAME + "%' ";
                if (null != model.BUILDORG)
                    whereClause += " and BUILDORG like '%" + model.BUILDORG + "%' ";
                if (null != model.BUILDADRESS)
                    whereClause += " and BUILDADRESS like '%" + model.BUILDADRESS + "%' ";

                if (null != model.CREATETIMESTART)
                    whereClause += " and CREATETIME >= to_date('" + model.CREATETIMESTART + "','yyyy-mm-dd') ";
                if (null != model.CREATETIMEEND)
                    whereClause += " and CREATETIME <= to_date('" + model.CREATETIMEEND + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMESTART)
                    whereClause += " and ENDTIME >= to_date('" + model.ENDTIMESTART + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMEEND)
                    whereClause += " and ENDTIME <= to_date('" + model.ENDTIMEEND + "','yyyy-mm-dd') ";

                list = orm.Query<SYS_PROJECT>(whereClause);
            }
            foreach (SYS_PROJECT prj in list)
            {
                prj._parentId = prj.PID;
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(new { rows = list }));
            System.Web.HttpContext.Current.Response.End();
            return Json(new { rows = list });
        }
        public ActionResult Projectsed(SearchViewModel model)
        {
            List<SYS_PROJECT> list = null;
            string UserId = Session["UserId"].ToString();
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                string whereClause = " where 1=1 ";
                whereClause += " and ID in (select ref_project_id from sys_projectworkitem where state=1) ";
                if (null != model.PROJECTNO)
                    whereClause += " and PROJECTNO like '%" + model.PROJECTNO + "%' ";
                if (null != model.PROJECTNAME)
                    whereClause += " and PROJECTNAME like '%" + model.PROJECTNAME + "%' ";
                if (null != model.BUILDORG)
                    whereClause += " and BUILDORG like '%" + model.BUILDORG + "%' ";
                if (null != model.BUILDADRESS)
                    whereClause += " and BUILDADRESS like '%" + model.BUILDADRESS + "%' ";

                if (null != model.CREATETIMESTART)
                    whereClause += " and CREATETIME >= to_date('" + model.CREATETIMESTART + "','yyyy-mm-dd') ";
                if (null != model.CREATETIMEEND)
                    whereClause += " and CREATETIME <= to_date('" + model.CREATETIMEEND + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMESTART)
                    whereClause += " and ENDTIME >= to_date('" + model.ENDTIMESTART + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMEEND)
                    whereClause += " and ENDTIME <= to_date('" + model.ENDTIMEEND + "','yyyy-mm-dd') ";
                list = orm.Query<SYS_PROJECT>(whereClause);
            }
            foreach (SYS_PROJECT prj in list)
            {
                prj._parentId = prj.PID;
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(new { rows = list }));
            System.Web.HttpContext.Current.Response.End();
            return Json(new { rows = list });
        }
        public ActionResult ProjectsGlobal(SearchViewModel model)
        {
            List<SYS_PROJECT> list = null;
            string UserId = Session["UserId"].ToString();
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                string whereClause = " where 1=1 ";
                whereClause += " and ID in (select ref_project_id from sys_projectworkitem) ";
                if (null != model.PROJECTNO)
                    whereClause += " and PROJECTNO like '%" + model.PROJECTNO + "%' ";
                if (null != model.PROJECTNAME)
                    whereClause += " and PROJECTNAME like '%" + model.PROJECTNAME + "%' ";
                if (null != model.BUILDORG)
                    whereClause += " and BUILDORG like '%" + model.BUILDORG + "%' ";
                if (null != model.BUILDADRESS)
                    whereClause += " and BUILDADRESS like '%" + model.BUILDADRESS + "%' ";

                if (null != model.CREATETIMESTART)
                    whereClause += " and CREATETIME >= to_date('" + model.CREATETIMESTART + "','yyyy-mm-dd') ";
                if (null != model.CREATETIMEEND)
                    whereClause += " and CREATETIME <= to_date('" + model.CREATETIMEEND + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMESTART)
                    whereClause += " and ENDTIME >= to_date('" + model.ENDTIMESTART + "','yyyy-mm-dd') ";
                if (null != model.ENDTIMEEND)
                    whereClause += " and ENDTIME <= to_date('" + model.ENDTIMEEND + "','yyyy-mm-dd') ";
                list = orm.Query<SYS_PROJECT>(whereClause);
            }
            foreach (SYS_PROJECT prj in list)
            {
                prj._parentId = prj.PID;
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(new { rows = list }));
            System.Web.HttpContext.Current.Response.End();
            return Json(new { rows = list });
        }        
    }
}
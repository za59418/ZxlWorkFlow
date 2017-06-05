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
using Zxl.WebSite.Model;
using Zxl.WebSite.ModelView;
using Zxl.Printer;
using Zxl.Form.Sheet;

namespace Zxl.WebSite.Controllers
{
    public class ArchiveController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projectsing()
        {
            List<SYS_PROJECT> list = null;
            string UserId = Session["UserId"].ToString();
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECT>("where ID in (select ref_project_id from sys_projectworkitem where ref_user_id = " + UserId + " and state=0)");
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
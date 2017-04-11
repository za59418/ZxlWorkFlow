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
    public class WorkbenchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Projects()
        {
            List<SYS_PROJECT> list = null;
            using (ORMHandler orm = DCIIDS.Data.DatabaseManager.ORMHandler)
            {
                list = orm.Query<SYS_PROJECT>();
            }
            foreach(SYS_PROJECT prj in list)
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
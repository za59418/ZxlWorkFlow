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
        public ActionResult Index(ArchiveViewModel model)
        {
            return PartialView(model);
        }

        public ActionResult ArchiveData(ArchiveViewModel model)
        {
            List<SYS_ARCHIVE> list = null;
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                string whereClause = " where 1=1 ";

                if (null != model.PROJECTNO)
                    whereClause += " and PROJECTNO like '%" + model.PROJECTNO + "%' ";
                if (null != model.PROJECTNAME)
                    whereClause += " and PROJECTNAME like '%" + model.PROJECTNAME + "%' ";
                if (null != model.BUILDORG)
                    whereClause += " and BUILDORG like '%" + model.BUILDORG + "%' ";
                if (null != model.BUILDADRESS)
                    whereClause += " and BUILDADRESS like '%" + model.BUILDADRESS + "%' ";
                if (null != model.ARCHIVENO)
                    whereClause += " and ARCHIVENO like '%" + model.ARCHIVENO + "%' ";

                if (null != model.ARCHIVETIMESTART)
                    whereClause += " and ARCHIVETIME >= to_date('" + model.ARCHIVETIMESTART + "','yyyy-mm-dd') ";
                if (null != model.ARCHIVETIMEEND)
                    whereClause += " and ARCHIVETIME <= to_date('" + model.ARCHIVETIMEEND + "','yyyy-mm-dd') ";
                list = orm.Query<SYS_ARCHIVE>(whereClause);
            }

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Web.HttpContext.Current.Response.Write(jss.Serialize(new { rows = list }));
            System.Web.HttpContext.Current.Response.End();
            return Json(new { rows = list });
        }

    }
}
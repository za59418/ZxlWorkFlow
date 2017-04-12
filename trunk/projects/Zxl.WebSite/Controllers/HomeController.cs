using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Zxl.Data;
using Zxl.WebSite.Model;

namespace Zxl.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portal()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(string UserName,string Password)
        {
            SYS_USER user = null;

            HttpCookie cookie = new HttpCookie("User");
            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where USERNAME='" + UserName + "' and PASSWORD='" + Password + "'");
                if(null != user)
                {
                    Session["UserId"] = user.ID + "";
                    Session["UserName"] = user.USERNAME + "";
                    return View("Index");
                }
                else
                {
                    return View("Login");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Zxl.Data;
using Zxl.Business.Model;
using Zxl.WebSite.ModelView;
using Zxl.Business.Interface;
using Microsoft.Practices.Unity;

namespace Zxl.WebSite.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IMessageService MessageService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portal()
        {
            string UserId = Session["UserId"].ToString();
            List<SYS_MESSAGE> NoReadMsgs = MessageService.GetNoReadMsgs(UserId);
            return View(NoReadMsgs);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoLogin(LoginViewModel model, string returnUrl)
        {
            SYS_USER user = null;

            using (ORMHandler orm = Zxl.Data.DatabaseManager.ORMHandler)
            {
                user = orm.Init<SYS_USER>("where USERNAME='" + model.UserName + "' and PASSWORD='" + model.Password + "'");
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
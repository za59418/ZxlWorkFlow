using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace Zxl.WebSite
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool allow = false;
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0 ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)//可匿名访问
            {
                allow = true;
            }
            else
            {
                HttpCookie tokenCookie = HttpContext.Current.Request.Cookies.Get("APPTOKEN");
                allow = true;

                //if (tokenCookie != null && !string.IsNullOrEmpty(tokenCookie.Value))
                //{
                //    var userManager = DCI.Base.Web.IocFactory.GetObject<IAppUserManager>();
                //    APPTOKEN appToken;
                //    if (userManager.CheckAndUpdateToken(tokenCookie.Value, out appToken))
                //    {
                //        if (DciContext.Current != null)
                //        {
                //            DciContext.Current.AddObj("LOGINUSERID", appToken.USERID);
                //        }
                //        allow = true;
                //    }
                //}
            }
            if (allow)
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}
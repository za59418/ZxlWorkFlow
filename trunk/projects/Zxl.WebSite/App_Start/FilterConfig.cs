using System.Web;
using System.Web.Mvc;

namespace Zxl.WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CheckLoginAttribute());
        }

        public class CheckLoginAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                bool Pass = false;
                if (null == httpContext.Session["UserId"])
                {
                    Pass = false;
                }
                else
                {
                    Pass = true;
                }
                return Pass;
            }
        }
    }
}
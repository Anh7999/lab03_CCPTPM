
using System.Web.Mvc;

namespace TMDT.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Default", id = UrlParameter.Optional },
                namespaces: new string[] {"TMDT.Areas.Admin.Controllers"}
            );
        }
    }
}
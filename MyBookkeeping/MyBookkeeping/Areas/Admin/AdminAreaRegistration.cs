using System.Web.Mvc;

namespace MyBookkeeping.Areas.Admin
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
                             "skilltree",
                             "skilltree/{action}/{id}",
                             new { controller = "Journal", action = "Index", id = UrlParameter.Optional }
                            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
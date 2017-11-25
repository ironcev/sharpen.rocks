using System.Web.Mvc;
using System.Web.Routing;

namespace SharpenRocks
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{*anyurl}",
                new { controller = "Redirect", action = "Index" }
            );
        }
    }
}

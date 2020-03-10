using OnlineFlightBooking.App_Start;
using OnlineFlightBooking.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineFlightBooking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapConfig.RegisterMap();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}

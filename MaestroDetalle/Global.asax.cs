using MaestroDetalle.ConfigMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MaestroDetalle
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cgf => cgf.AddProfile<AutomapperConfig>());
        }
    }
}

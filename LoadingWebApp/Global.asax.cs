using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using LoadingApp.DataProvider;
using LoadingApp.DataProvider.Interfaces;
using LoadingApp.MathLib.Logic.Interfaces;
using LoadingApp.MathLib.Logic.ResultsProvider;
using LoadingApp.RenderDataProvider;
using LoadingApp.RenderDataProvider.Interfaces;

namespace LoadingWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<ModelingResultsProvider>().As<IModelingResultsProvider>();
            builder.RegisterType<VisualizationDataProvider>().As<IVisualizationDataProvider>();
            builder.RegisterType<PredefinedDataProvider>().As<IPredefinedDataProvider>();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

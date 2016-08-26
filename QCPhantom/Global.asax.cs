using QCPhantom.Domain;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QCPhantom
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Set the custom ControllerFactory as the default
            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));

            // Add the Controllers from this assembly to the ControllerFactory
            CustomControllerFactory.AddAssembly(Assembly.GetExecutingAssembly());
            CustomControllerFactory.AddAssembly(Assembly.LoadFile(@"D:\Developments\Git\QCPhantom\PIX-13\bin\Debug\PIX-13.dll"));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Add a rule for the Added Views
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            razorEngine.ViewLocationFormats =
                    razorEngine.ViewLocationFormats.Concat(new string[] {
                    "~/Phantoms/{1}/{0}.cshtml",
                    "~/Phantoms/{0}.cshtml"
                    }).ToArray();
        }
    }
}

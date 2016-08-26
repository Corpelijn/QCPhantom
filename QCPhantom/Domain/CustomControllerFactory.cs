using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace QCPhantom.Domain
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private static List<Type> knownControllers = new List<Type>();

        public static void AddAssembly(Assembly assembly)
        {
            knownControllers.AddRange(assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.EndsWith("Controllers")));
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            string controllername = requestContext.RouteData.Values["controller"].ToString() + "Controller";
            Type type = knownControllers.FirstOrDefault(t => t.Name == controllername);

            // Create an instance of the controller
            return type == null ? null : Activator.CreateInstance(type) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            IDisposable dispose = controller as IDisposable;
            if (dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}
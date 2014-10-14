using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Infrastrcuture
{
    public class PluginControllerFactory : IControllerFactory
    {
        private readonly DefaultControllerFactory _defaultControllerFactory;
 
        public PluginControllerFactory()
        {

            _defaultControllerFactory = new DefaultControllerFactory();
        }

        public DefaultControllerFactory DefaultControllerFactory
        {
            get { return _defaultControllerFactory; }
        }

        public IController CreateController(System.Web.Routing.RequestContext request_context, string controller_name)
        {
            var controller = Bootstrapper.GetInstance<IController>(controller_name);
            if (controller == null)
            {
                throw new Exception("Plugin Controller Not Found");
            }

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext request_context, string controller_name)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;

            if (disposableController != null)
            {
                disposableController.Dispose();
            }
        }
    }
}

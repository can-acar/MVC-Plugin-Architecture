using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Infrastrcuture
{
    using System.Web.Mvc;
    public class PluginControllerFactoryOLD : DefaultControllerFactory
    {
        private readonly CompositionContainer _compositionContainer;

        public PluginControllerFactoryOLD(CompositionContainer composition_container)
        {
            _compositionContainer = composition_container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            //return base.GetControllerInstance(requestContext, controllerType);
            var export = _compositionContainer.GetExports(controllerType, null, null).SingleOrDefault();
            IController resultController;
            if (null != export)
            {
                resultController = export.Value as IController;
            }
            else
            {
                resultController = base.GetControllerInstance(requestContext, controllerType);
                _compositionContainer.ComposeParts(resultController);

            }
            return resultController;
        }
    }
}

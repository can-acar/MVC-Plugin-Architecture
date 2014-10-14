using System.Web.Mvc;

namespace Plugins.Controllers
{
    [Export("DemoPlugin", typeof(IController))]
    [PartCreationPolicy]
    public class DemoPluginController:Controller
    {
    }
}

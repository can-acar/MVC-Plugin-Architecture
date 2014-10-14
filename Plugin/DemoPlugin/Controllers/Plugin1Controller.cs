using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace DemoPlugin.Controllers
{
    [Export("Plugin1", typeof(IController))]
    [System.Composition.ExportMetadata("controllerName", "Plugin1")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Plugin1Controller : Controller
    {
        // GET: Plugin1
        public ActionResult Index()
        {
            return View();
        }
    }
}
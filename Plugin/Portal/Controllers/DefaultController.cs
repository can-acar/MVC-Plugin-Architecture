using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Portal.Controllers
{
    [Export("Default", typeof(IController))]
    [System.Composition.ExportMetadata("controllerName", "Default")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}
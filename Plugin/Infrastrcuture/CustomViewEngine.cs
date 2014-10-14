using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infrastrcuture
{
    public class CustomViewEngine : RazorViewEngine
    {
        private readonly IList<string> _pluginList = new List<string>();
 public CustomViewEngine(IList<string> plugin_folders)
        {
            _pluginList = plugin_folders;
            ViewLocationFormats = GetViewLocations();
            MasterLocationFormats = GetMasterLocations();
            PartialViewLocationFormats = GetViewLocations();
        }


        private string[] GetMasterLocations()
        {
            var masterPages = new List<string> { "~/Views/Shared/{0}.cshtml" };
            _pluginList.ToList().ForEach(plugin => masterPages.Add("~/Modules/" + plugin + "/Views/Shared/{0}.cshtml"));

            return masterPages.ToArray();
        }

        private string[] GetViewLocations()
        {
            var views = new List<string> { "~/Views/{1}/{0}.cshtml" };
            _pluginList.ToList().ForEach(plugin => views.Add("~/Modules/" + plugin + "/Views{1}/{0}.cshtml"));
            return views.ToArray();
        }
    }

}

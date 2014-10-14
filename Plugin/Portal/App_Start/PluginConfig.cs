using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Infrastrcuture;

namespace Portal
{
    public class PluginConfig
    {
        public static void Init()
        {
            var pluginFolders = new List<string>();
            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules")).ToList();

            plugins.ForEach(q =>
            {
                var di = new DirectoryInfo(q);
                pluginFolders.Add(di.Name);
            });
            
            Bootstrapper.Compose(pluginFolders);
            ControllerBuilder.Current.SetControllerFactory(new PluginControllerFactory());
            ViewEngines.Engines.Add(new PluginViewEngine(pluginFolders));
        }
    }
}
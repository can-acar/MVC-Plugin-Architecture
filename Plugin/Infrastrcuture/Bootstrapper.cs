using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace Infrastrcuture
{
    public class Bootstrapper
    {
        private static CompositionContainer _compositionContainer;
        private static bool _isLoaded = false;

        public static void Compose(IList<string> plugin_folders_list)
        {
            if (_isLoaded) return;

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

            foreach (var directoryCatalog in plugin_folders_list.Select(plugin => new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", plugin))))
            {
                catalog.Catalogs.Add(directoryCatalog);
            }

            _compositionContainer = new CompositionContainer(catalog);
            _compositionContainer.ComposeParts();
            _isLoaded = true;
        }

        public static T GetInstance<T>(string contract_name = null)
        {
            var type = default(T);
            if (_compositionContainer == null) return type;

            type = !string.IsNullOrWhiteSpace(contract_name) ? _compositionContainer.GetExportedValue<T>(contract_name) : _compositionContainer.GetExportedValue<T>();

            return type;
        }
    }
}

using System.Collections.Generic;


namespace Infrastrcuture
{
    public class PluginBootstrapper:IPluginBootstrapper
    {
        private readonly IList<string> _plugingFolders = new List<string>();

        public void AddFolder(string folder_name)
        {
            _plugingFolders.Add(folder_name);
        }
    }
}

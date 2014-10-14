using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public interface IPugin
    {
        string Title { get; }
        string Name { get; }

        Version Version { get; }

        string ControllerName { get; }

        void Install();
    }
}

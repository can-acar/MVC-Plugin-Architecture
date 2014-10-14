using System;

namespace Infrastrcuture
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

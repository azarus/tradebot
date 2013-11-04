using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Plugin
{
    public interface IPluginInterface
    {
        string Name { get; }
        string Version { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Plugin;

namespace Plugin
{
    public class CPlugin : IPluginInterface
    {
        public string Name { get { return "TestPlugin"; } }
        public string Version { get { return "v1.0"; } }
    }
}

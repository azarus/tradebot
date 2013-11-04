using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Resources;

using Library.Helpers;
using Library.Plugin;

namespace Tradebot.Core
{
    class CPluginHosting
    {
        public Dictionary<string, IPluginInterface> plugins = new Dictionary<string, IPluginInterface>();
        Type pluginType = typeof(IPluginInterface);
        public CPluginHosting(string path)
        {
            CConsole.PRINT("Loading plugins.");
            List<string> dllFiles = Directory.GetFiles(path).ToList<string>();
            foreach (string file in dllFiles)
            {
                this.LoadDLL(file);
            }
        }
        public void LoadDLL(string file)
        {
            if (file.Contains(".dll"))
            {
                AssemblyName an = AssemblyName.GetAssemblyName(file);
                Assembly assembly = Assembly.Load(an);
                if (assembly != null)
                {

                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                IPluginInterface plugin = (IPluginInterface)Activator.CreateInstance(type);
                                CConsole.PRINT(plugin.Name + " " + plugin.Version + " loaded successfully.");
                                FileInfo info = new FileInfo(file);
                                plugins.Add(info.Name.Replace(".dll", ""), plugin);
                                return;
                            }
                        }
                    }
                }
                CConsole.WARN("It was unable to load '" + file + "'");
            }
            else
            {
                CConsole.WARN("'" + file + "' is not a .dll file");
            }
        }
    }
}

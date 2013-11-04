using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Tradebot;
using Library.Helpers;

namespace Tradebot.Core
{
    public class CApplication
    {
        CPluginHosting CPluginHost;
        public CApplication()
        {
            if (!Directory.Exists("logs/"))
            {
                Directory.CreateDirectory("logs/");

                CConsole.WARN("Directory 'logs/' was missing!");
            }

            CConsole.PRINT("Console initialized...");
            CConsole.PRINT("-----------------------------------------");
            CConsole.GOOD(Settings.ApplicationName);
            CConsole.GOOD("Created By " + Settings.Developer + " - " + Settings.Version + " " + Settings.Date);
            CConsole.PRINT("-----------------------------------------");

            if (!Directory.Exists("mods"))
            {
                CConsole.ERROR("No 'mods/' directory found. What now?");
            }

            CPluginHost = new CPluginHosting("mods");

            CConfig mainCFG = new CConfig("settings.cfg");
            CMySql sql = new CMySql(
                    mainCFG.GetCvar("sql_host").String(),
                    mainCFG.GetCvar("sql_user").String(),
                    mainCFG.GetCvar("sql_pass").String(),
                    mainCFG.GetCvar("sql_port").String()
                    );
            Query query = sql.Query("SELECT * FROM accounts");
            Row row = new Row();
            while (query.Fetch(row))
            {
                CConsole.DEBUG("USERNAME: " + row.String("username"));
            }
        }

        public void Tick()
        {
            
        }
    }
}

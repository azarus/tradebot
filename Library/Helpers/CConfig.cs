using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

using Library.Helpers;

namespace Library.Helpers
{
    public class Cvar
    {
        string value;
        public Cvar(string value)
        {
            this.value = value;
        }
        public int Int()
        {
            return Convert.ToInt32(this.value);
        }
        public string String()
        {
            return this.value;
        }
        public bool Bool()
        {
            try
            {
                return Convert.ToBoolean(this.value);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public float Float()
        {
            return float.Parse(this.value);
        }
    }
    public class CConfig
    {
        Dictionary<string, Cvar> CvarList = new Dictionary<string, Cvar>();
        string szFileName;
        public CConfig(string szFileName)
        {
            this.szFileName = szFileName;
            try
            {
                StreamReader m_hFile = new StreamReader(szFileName);
                string line;
                while ((line = m_hFile.ReadLine()) != null)
                {
                    string[] match = Regex.Split(line, "(.*)=(.*)", RegexOptions.IgnoreCase);
                    CConsole.DEBUG("CVAR: " + match[1] + " => " + match[2]);
                    CvarList.Add(match[1], new Cvar(match[2]));
                }
                m_hFile.Close();
            }
            catch (IOException)
            {
                CConsole.ERROR("Unable to read file '" + szFileName + "'.");
            }

        }
        public Cvar GetCvar(string szCvar)
        {
            if (!CvarList.ContainsKey(szCvar))
            {
                CConsole.DEBUG("No CVAR '" + szCvar + "' found in '" + this.szFileName + "'");
                return new Cvar("0");
            }
            else
            {
                return CvarList[szCvar];
            }
        }
    }
}

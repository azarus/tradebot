using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Timers;

namespace Library.Helpers
{
    public class CConsole
    {
        public static void PRINT(string line)
        {
            CConsole.ColoredConsoleWriteLine(ConsoleColor.White, line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + line);
        }

        public static void DEBUG(string line)
        {
            CConsole.ColoredConsoleWriteLine(ConsoleColor.Gray, "[DEBUG] " + line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] [DEBUG] " + line);
        }

        public static void WARN(string line)
        {

            CConsole.ColoredConsoleWriteLine(ConsoleColor.Yellow, "[WARNING] " + line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] [WARNING] " + line);
        }

        public static void NOTE(string line)
        {

            CConsole.ColoredConsoleWriteLine(ConsoleColor.Magenta, "[NOTE] " + line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] [NOTE] " + line);
        }

        public static void GOOD(string line)
        {
            CConsole.ColoredConsoleWriteLine(ConsoleColor.Green, line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + line);
        }

        public static void ERROR(string line)
        {
            CConsole.ColoredConsoleWriteLine(ConsoleColor.Red, "[ERROR] " + line);
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] [ERROR] " + line);
            CConsole.ColoredConsoleWriteLine(ConsoleColor.Red, "Terminating...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void ColoredConsoleWriteLine(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text);
            Console.ForegroundColor = originalColor;
        }

        public static void ColoredConsoleWrite(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text);
            Console.ForegroundColor = originalColor;
        }

        public static void LOG(string line)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream("logs/" + DateTime.Today.ToString("yyyy.M.d") + ".log", FileMode.Append)))
            {
                writer.WriteLine(line);
            }
        }

        public static string Ask(string line)
        {
            CConsole.ColoredConsoleWrite(ConsoleColor.Cyan, "[?!] " + line + " : ");
            LOG("[" + DateTime.Now.ToString("HH:mm:ss") + "] Asking user: " + line);
            return Console.ReadLine();
        }
    }
}

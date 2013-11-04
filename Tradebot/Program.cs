using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tradebot.Core;

namespace Tradebot
{
    class Program
    {
        static void Main(string[] args)
        {
            CApplication app = new CApplication();
            while (true)
            {
                app.Tick();
            }
        }
    }
}

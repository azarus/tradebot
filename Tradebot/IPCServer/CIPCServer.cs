using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Tradebot.IPCServer
{
    class CIPCServer
    {
        private TcpListener tcpServer;
        List<CIPCClient> clients = new List<CIPCClient>();
        public CIPCServer(string ip, int port)
        {

        }      
    }
}

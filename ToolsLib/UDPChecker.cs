using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolsLib
{
    public class UDPChecker
    {
        private readonly UdpClient _client;
        private readonly IPAddress _ip;
        private readonly IPEndPoint _ipEP;
        private readonly int _port;

        private readonly CancellationToken _cancellationToken;

        public UDPChecker(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
            _ipEP = new IPEndPoint(_ip, _port);
            _client = new UdpClient(_ipEP);
        }

        public void Run()
        {
            try
            {
                _client.BeginReceive(new AsyncCallback(Recv), null);
            }
            catch (Exception e)
            {
            }
        }

        private void Recv(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, _port);
            byte[] received = _client.EndReceive(res, ref RemoteIpEndPoint);

        }
    }
}

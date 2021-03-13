using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToolsLib.Cryptor;
using ToolsLib.Interfaces;

namespace ToolsLib
{
    public class UDPChecker
    {
        private readonly UdpClient _client;
        private readonly IPAddress _ip;
        private readonly IPEndPoint _ipEP;
        private readonly List<Task> _tasks;
        private readonly int _port;
        private IPEndPoint _anyIPEP;

        public UDPChecker(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
            _ipEP = new IPEndPoint(_ip, _port);
            _client = new UdpClient(_ipEP);
            _tasks = new List<Task>();
            _anyIPEP = new IPEndPoint(IPAddress.Any, _port);
        }

        public void Run(IMessageHandler handler, CancellationToken cancellationToken)
        {
            var cancelWaitTask = Task.Run(() =>
            {
                using (var resetEvent = new ManualResetEvent(false))
                {
                    cancellationToken.Register(() => resetEvent.Set());
                    resetEvent.WaitOne();
                }
            });
            Task.Run(() => {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("StartRec");
                    var recieved = _client.Receive(ref _anyIPEP);

                    Task.WaitAny(cancelWaitTask);
                    if (cancelWaitTask.IsCompleted)
                    {
                        break;
                    }
                    Console.WriteLine("StartAft");

                    var task = Task.Run(() => ReceiveMessage(recieved));
                    Console.WriteLine("Task");

                    _tasks.Add(task);
                }
                Task.WaitAll(_tasks.ToArray());
            });
        }

        public void Send(string data, IPAddress ip)
        {
            var client = new UdpClient();
            client.Connect(new IPEndPoint(ip, _port));
            if (!string.IsNullOrEmpty(data))
            {
                var dBytes = Encoding.UTF8.GetBytes(data);
                client.Send(dBytes, dBytes.Length);
            }
        }

        private void ReceiveMessage(object res)
        {
            Console.WriteLine("!!!!!!!!RECIVE!!!!!!!!!");
        }
    }
}

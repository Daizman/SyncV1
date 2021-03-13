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

        public UDPChecker(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
            _ipEP = new IPEndPoint(_ip, _port);
            _client = new UdpClient(_ipEP);
            _tasks = new List<Task>();
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
            Task.Run(()=> {
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var recieved = _client.ReceiveAsync();
                        Task.WaitAny(recieved, cancelWaitTask);

                        if (cancelWaitTask.IsCompleted)
                        {
                            break;
                        }

                        var task = Task.Run(() => ReceiveMessage(handler, recieved.Result));

                        _tasks.Add(task);
                    }
                }
                catch (Exception e)
                {
                }
            });
            
        }

        public void Send(string data, string ip)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var dBytes = Encoding.UTF8.GetBytes(data);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("!!!!!!!!!ИУАSEND!!!!!!!!!!");
                Console.ResetColor();
                _client.SendAsync(dBytes, dBytes.Length, ip, _port);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("!!!!!!!!!SEND!!!!!!!!!!");
                Console.ResetColor();
            }
        }

        private void ReceiveMessage(IMessageHandler handler, UdpReceiveResult res)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!!!!!!RECIVE!!!!!!!!!");
            Console.ResetColor();
        }
    }
}

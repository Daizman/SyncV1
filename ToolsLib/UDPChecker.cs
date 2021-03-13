﻿using Newtonsoft.Json;
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
            var recieved = _client.Receive(ref _anyIPEP);
            Task.Run(() => ReceiveMessage(handler, recieved));
        }

        public void Send(string data, string ip)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var dBytes = Encoding.UTF8.GetBytes(data);
                _client.Send(dBytes, dBytes.Length, ip, _port);
                Console.WriteLine("!!!!!!!!!SEND!!!!!!!!!!");
            }
        }

        private void ReceiveMessage(IMessageHandler handler, object res)
        {
            Console.WriteLine("!!!!!!!!RECIVE!!!!!!!!!");
        }
    }
}

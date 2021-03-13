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
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(_port); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.UTF8.GetString(data);
                    Console.WriteLine($"Data{message}, ip:{remoteIp}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
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

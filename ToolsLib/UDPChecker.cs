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
        }

        public void Send(string data, string ip)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var dBytes = Encoding.UTF8.GetBytes(data);
                _client.SendAsync(dBytes, dBytes.Length, ip, _port);
            }
        }

        private void ReceiveMessage(IMessageHandler handler, UdpReceiveResult res)
        {
            var resc = 1;
            var stp = 1;
        }

        private DESCryptoServiceProvider GetDES(Socket socket)
        {
            var rsa = Cryptographer.GetRSA();

            var publicKey = rsa.ExportParameters(false);
            var privateKey = rsa.ExportParameters(true);

            var rsaBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new RSAPublicKeyParameters(publicKey)));
            socket.Send(rsaBytes);

            var buffer = new byte[1024];
            var sizeDES = socket.Receive(buffer);
            var encryptedDES = new byte[sizeDES];
            Array.Copy(buffer, 0, encryptedDES, 0, sizeDES);
            var encryptedDESstr = Encoding.UTF8.GetString(encryptedDES);

            var encrypdedDesParams = JsonConvert.DeserializeObject<DESParameters>(encryptedDESstr);

            var desIV = Cryptographer.RSADecrypt(encrypdedDesParams.IV, privateKey);
            var desKey = Cryptographer.RSADecrypt(encrypdedDesParams.Key, privateKey);

            var des = Cryptographer.GetDES(desIV, desKey);


            return des;
        }
    }
}

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
        private ConcurrentDictionary<Tuple<string, int>, TaskCompletionSource<byte[]>> _tcsDictionary;
        private UdpClient _client;

        public UDPChecker(IPAddress ip, int port)
        {
            _client = new UdpClient(new IPEndPoint(ip, port));
            _tcsDictionary = new ConcurrentDictionary<Tuple<string, int>, TaskCompletionSource<byte[]>>();
        }

        public async Task<byte[]> SendReceiveAsync(byte[] msg, string ip, int port, int timeOut)
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var endPointTP = new Tuple<string, int>(ip, port);
            var tcs = new TaskCompletionSource<byte[]>();

            try
            {
                var tokenSource = new CancellationTokenSource(timeOut);
                var token = tokenSource.Token;
                if (!_tcsDictionary.ContainsKey(endPointTP))
                {
                    _tcsDictionary.TryAdd(endPointTP, tcs);
                }
                _client.Send(msg, msg.Length, ip, port);

                var result = await tcs.Task.WithCancellation(token);
                return result;
            }

            finally
            {
                _tcsDictionary.TryRemove(endPointTP, out tcs);
            }
        }

        public void Run()
        {
            Task.Run(() =>
            {
                IPEndPoint ipEndPoint = null;

                while (true)
                {
                    try
                    {
                        var receivedBytes = _client.Receive(ref ipEndPoint);
                        var ipEndPointTP = new Tuple<string, int>(ipEndPoint.Address.ToString(), ipEndPoint.Port);
                        TaskCompletionSource<byte[]> tcs;
                        if (_tcsDictionary.TryGetValue(ipEndPointTP, out tcs))
                        {
                            tcs.SetResult(receivedBytes);
                        }
                    }
                    catch (SocketException)
                    {
                        ;//при невозможности соединения продолжаем работать
                    }

                }
            });
        }
    }
}

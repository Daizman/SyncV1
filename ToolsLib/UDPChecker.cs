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
using System.Windows.Forms;
using ToolsLib.Cryptor;
using ToolsLib.Interfaces;
using ToolsLib.UserClasses;

namespace ToolsLib
{
    public class UDPChecker
    {
        private readonly int _port;
        private readonly User _user;
        private IMessageHandler _messageHandler;
        private UdpClient _reciv;

        public UDPChecker(int port, User user)
        {
            _port = port;
            _user = user;
        }

        public void Run(IMessageHandler handler, CancellationToken cancellationToken)
        {
            _messageHandler = handler;
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
            try
            {
                _reciv = new UdpClient(_port); // UdpClient для получения данных
                IPEndPoint remoteIp = null; // адрес входящего подключения
                while (true)
                {
                    byte[] data = _reciv.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.UTF8.GetString(data);
                    Console.WriteLine("MESSAGE:" + message);
                    if (_user.PublicKey == message)
                    {
                        if (_user.UserDirectory.Path == "")
                        {
                            var test = MessageBox.Show($"Хотите получить доступ к директории пользователя: {remoteIp}?", "Доступ", MessageBoxButtons.YesNo);
                            if (test == DialogResult.Yes)
                            {
                                var goodAnswer = new Tuple<bool, User>(true, _user);
                                var answJson = JsonConvert.SerializeObject(goodAnswer);
                                Send(answJson, remoteIp.Address);
                            }
                            else
                            {
                                Send("DENIED", remoteIp.Address);
                            }
                        }
                        else
                        {
                            Send("HAVEDIR", remoteIp.Address);
                        }
                    }
                    else if (message == "HAVEDIR")
                    {
                        _messageHandler.HandleMessage(null, null);
                    }
                    else if (message == "DENIED") 
                    {
                        _messageHandler.HandleMessage(null, remoteIp);
                    }
                    try
                    {
                        var answ = JsonConvert.DeserializeObject<Tuple<bool, User>>(message);
                        if (answ.Item1)
                        {
                            _messageHandler.HandleMessage(answ.Item2, remoteIp);
                        }
                    }
                    catch
                    {

                    }
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

        public void Close()
        {
            _reciv.Close();
        }

        public void Send(string data, IPAddress ip)
        {
            var client = new UdpClient();
            var end = new IPEndPoint(ip, _port);
           // client.Connect(end);
            if (!string.IsNullOrEmpty(data))
            {
                var dBytes = Encoding.UTF8.GetBytes(data);
                client.Send(dBytes, dBytes.Length, end);
            }
        }
    }
}

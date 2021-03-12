using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using ToolsLib.Cryptor;

namespace ToolsLib
{
    public class SockProd
    {
        private readonly IPEndPoint _ipEP;
        private readonly IPAddress _ip;

        public SockProd(IPAddress ip, int port)
        {
            _ip = ip;
            _ipEP = new IPEndPoint(ip, port);
        }

        public void Send(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    var socket = new Socket(_ip.AddressFamily, SocketType.Stream, ProtocolType.Udp);
                    socket.Connect(_ipEP);

                    var des = GetDES(socket);

                    var encryptedData = Cryptographer.SymmetricEncrypt(data, des);
                    //отправляем данные
                    socket.Send(encryptedData);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket.Dispose();
                }
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        private DESCryptoServiceProvider GetDES(Socket socket, string publicUserKey)
        {
            var buffer = new byte[1024];

            // Принимаем RSA public
            var sizeRSA = socket.Receive(buffer);
            var publicKeyJsonByte = new byte[sizeRSA];
            Array.Copy(buffer, 0, publicKeyJsonByte, 0, sizeRSA);

            var publicKeyJson = Encoding.UTF8.GetString(publicKeyJsonByte);
            var publicKey = JsonConvert.DeserializeObject<RSAPublicKeyParameters>(publicUserKey);
            var publicKeyParameters = publicKey.GetRSAParameters();

            var des = Cryptographer.GetDES();
            var iv = Cryptographer.RSAEncrypt(des.IV, publicKeyParameters);
            var key = Cryptographer.RSAEncrypt(des.Key, publicKeyParameters);

            var encrypdedDes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new DESParameters(iv, key)));
            //отправляем ключ
            socket.Send(encrypdedDes);

            return des;
        }
    }
}

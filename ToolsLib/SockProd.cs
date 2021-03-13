using Newtonsoft.Json;
using System;
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
        private readonly string _publicKey;

        public SockProd(IPAddress ip, int port, string publicKey)
        {
            _ip = ip;
            _ipEP = new IPEndPoint(_ip, port);
            _publicKey = publicKey;
        }

        public void Send(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    var socket = new Socket(_ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                    socket.Bind(_ipEP);

                    var des = GetDES(socket);

                    var encryptedData = Cryptographer.SymmetricEncrypt(data, des);
                    //отправляем данные
                    socket.SendTo(encryptedData, _ipEP);

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

        private DESCryptoServiceProvider GetDES(Socket socket)
        {
            var buffer = new byte[1024];

            // Принимаем RSA public
            EndPoint ipTemp = new IPEndPoint(_ip, 11000);
            var sizeRSA = socket.ReceiveFrom(buffer, ref ipTemp);
            var publicKeyJsonByte = new byte[sizeRSA];
            Array.Copy(buffer, 0, publicKeyJsonByte, 0, sizeRSA);

            var publicKeyJson = Encoding.UTF8.GetString(publicKeyJsonByte);

            var publicKey = JsonConvert.DeserializeObject<RSAPublicKeyParameters>(publicKeyJson);
            var publicKeyParameters = publicKey.GetRSAParameters();

            var des = Cryptographer.GetDES();
            var iv = Cryptographer.RSAEncrypt(des.IV, publicKeyParameters);
            var key = Cryptographer.RSAEncrypt(des.Key, publicKeyParameters);

            var encrypdedDes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new DESParameters(iv, key)));
            //отправляем ключ
            socket.SendTo(encrypdedDes, _ipEP);

            return des;
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketSample.Server
{
    class SocketSampleServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Socket Server.");

            var remoteIp = IPAddress.Any;
            var receivePort = 12345;

            //Socketの作成
            using var sock = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);

            sock.Bind(new IPEndPoint(remoteIp, receivePort));

            byte[] bytes = null; 
            while (true)
            {
                // IPEndPoint remoteEp = null;
                IPEndPoint remoteEp = new IPEndPoint(remoteIp, receivePort);

                bytes = new byte[256];
                var receiveBytes = sock.Receive(bytes);

                var receiveMsg = Encoding.UTF8.GetString(bytes);

                Console.WriteLine($"receiveData   : {receiveMsg}");
                //Console.WriteLine($"remoteAddress : {remoteEp.Address}");
                //Console.WriteLine($"remotePort    : {remoteEp.Port}");

                if (receiveMsg == "exit") break;
            }
            sock.Close();

        }
    }
}

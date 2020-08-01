using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpSample.Server2
{
    class UdpSampleServer2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Udp Server2.");

            var receiveIp = IPAddress.Parse("127.0.0.1");
            var remoteIp = IPAddress.Any;
            var receivePort = 12345;

            using var udpReceive = new UdpClient();
            udpReceive.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpReceive.Client.Bind(new IPEndPoint(remoteIp, receivePort));

            while (true)
            {
                // IPEndPoint remoteEp = null;
                IPEndPoint remoteEp = new IPEndPoint(remoteIp, receivePort);
                
                var receiveBytes = udpReceive.Receive(ref remoteEp);

                var receiveMsg = Encoding.UTF8.GetString(receiveBytes);

                Console.WriteLine($"receiveData   : {receiveMsg}");
                Console.WriteLine($"remoteAddress : {remoteEp.Address}");
                Console.WriteLine($"remotePort    : {remoteEp.Port}");

                if (receiveMsg == "exit") break;
            }
            udpReceive.Close();
        }
    }
}

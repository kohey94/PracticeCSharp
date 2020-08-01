using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpSample.Server
{
    class UdpServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Udp Server.");

            var receiveIp = "127.0.0.1";
            var receivePort = 12345;

            using var udpReceive = new UdpClient(
                new IPEndPoint(IPAddress.Parse(receiveIp), receivePort));
            
            while (true)
            {
                IPEndPoint remoteEp = null;
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

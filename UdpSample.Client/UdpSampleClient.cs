using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpSample.Client
{
    class UdpSampleClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Udp Client.");

            // var sendIp = IPAddress.Parse("255.255.255.255");
            var sendIp = IPAddress.Broadcast ;
            var sendPort = 12345;

            using var udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            while (true)
            {
                var sendMsg = Console.ReadLine();
                var sendBytes = Encoding.UTF8.GetBytes(sendMsg);

                // udpClient.Send(sendBytes, sendBytes.Length, sendIp, sendPort);
                // udpClient.Send(sendBytes, sendBytes.Length);
                udpClient.Send(sendBytes, sendBytes.Length, new IPEndPoint(sendIp, sendPort));

                if (sendMsg == "exit") break;
            }
            udpClient.Close();            
        }
    }
}

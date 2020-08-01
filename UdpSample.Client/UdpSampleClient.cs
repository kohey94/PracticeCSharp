using System;
using System.Net.Sockets;
using System.Text;

namespace UdpSample.Client
{
    class UdpSampleClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Udp Client.");

            var sendIp = "127.0.0.1";
            var sendPort = 12345;

            using var udpClient = new UdpClient();
            while (true)
            {
                var sendMsg = Console.ReadLine();
                var sendBytes = Encoding.UTF8.GetBytes(sendMsg);

                udpClient.Send(sendBytes, sendBytes.Length, sendIp, sendPort);
                
                if (sendMsg == "exit") break;
            }
            udpClient.Close();            
        }
    }
}

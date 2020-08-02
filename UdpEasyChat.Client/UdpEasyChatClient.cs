using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpEasyChat.Client
{
    class UdpEasyChatClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UdpEasyChatClient.");
            Console.WriteLine("------------------");
            Console.Write("名前を入力してください:");
            var name = Console.ReadLine();

            var sendIp = IPAddress.Broadcast;
            var sendPort = 12345;

            using var udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            
            try
            {
                while (true)
                {
                    var sendMsg = Console.ReadLine();
                    
                    // TODO 共通クラスにメッセージentityほしい（GUI化したとき用）
                    var sendBytes = Encoding.UTF8.GetBytes(name + " " + sendMsg);

                    udpClient.Send(sendBytes, sendBytes.Length, new IPEndPoint(sendIp, sendPort));

                    if (sendMsg == "exit") break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}

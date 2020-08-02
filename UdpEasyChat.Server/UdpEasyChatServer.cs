using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpEasyChat.Server
{
    class UdpEasyChatServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is UdpEasyChat Server.");
            Console.WriteLine("---------------------------");
            var remoteIp = IPAddress.Any;
            var receivePort = 12345;

            using var udpReceive = new UdpClient();
            udpReceive.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpReceive.Client.Bind(new IPEndPoint(remoteIp, receivePort));

            var ChatLogList = new List<ChatLog>();
            try
            {
                while (true)
                {
                    IPEndPoint remoteEp = null;

                    var receiveBytes = udpReceive.Receive(ref remoteEp);

                    var receiveMsg = Encoding.UTF8.GetString(receiveBytes);
                    // メッセージ受信形式はname+" "+message
                    var msg = receiveMsg.Split(" ");
                    var log = new ChatLog(msg[0], msg[1]);

                    ChatLogList.Add(log);
                    //ChatLogList.ForEach(x => { Console.WriteLine($"{x.WritingTime} {x.UserName} {x.Message}"); });

                    Console.WriteLine($"{log.WritingTime} {log.UserName} {log.Message}");

                    if (msg[1] == "exit") break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                udpReceive.Close();
            }
        }
    }
}

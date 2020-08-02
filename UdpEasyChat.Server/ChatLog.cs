using System;
using System.Collections.Generic;
using System.Text;

namespace UdpEasyChat.Server
{
    public class ChatLog
    {

        public DateTime WritingTime { get; private set; }
        public string UserName { get; private set; }
        public string Message { get; private set; }

        public ChatLog(string userName,string message)
        {
            WritingTime = DateTime.Now;
            UserName = userName;
            Message = message;
        }
    }
}

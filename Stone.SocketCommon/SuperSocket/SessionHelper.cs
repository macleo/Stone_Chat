using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    /// 会话帮助类
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// 发送消息（数据经过base54位编码）
        /// </summary>
        /// <param name="session"></param>
        /// <param name="message"></param>
        public static void SendMessage(ChatsSession session,string message)
        {
            session.Send("@@" + Utils.EncodeBase64(message) + "\r\n");
        }
    }
}

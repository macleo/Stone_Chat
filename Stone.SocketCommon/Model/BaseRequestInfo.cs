using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    ///  请求信息基础类
    /// </summary>
    public class BaseRequestInfo : IRequestInfo
    {
        public string Key { get; set; }
        /// <summary>
        /// 消息类型(login-登录 text-文本)
        /// </summary>
        public MsgType MsgType { get; set; }
    }
}

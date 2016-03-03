using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    ///  文本请求信息基础类
    /// </summary>
    public class TextRequestInfo : IBaseRequestInfo
    {
        public string Key { get; set; }
        /// <summary>
        /// 发送方用户名
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 接收方用户名
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 消息类型(register-注册 login-登录 text-文本)
        /// </summary>
        public MsgType MsgType { get; set; }
    }
}

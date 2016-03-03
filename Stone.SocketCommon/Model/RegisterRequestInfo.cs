using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    ///  注册请求信息基础类
    /// </summary>
    public class RegisterRequestInfo : IBaseRequestInfo
    {
        public string Key { get; set; }
        /// <summary>
        /// 发送方帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 接收方帐号
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType MsgType { get; set; }
    }
}

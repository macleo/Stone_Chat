using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    ///  错误信息基础类
    /// </summary>
    public class ErrorRequestInfo : IBaseRequestInfo
    {
        public string Key { get; set; }
        
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息类型(register-注册 login-登录 text-文本)
        /// </summary>
        public MsgType MsgType
        {
            get { return MsgType.Error; }
            set { }
        }
    }
}

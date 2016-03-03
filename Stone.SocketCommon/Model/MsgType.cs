using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    public enum MsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text = 1001,
        /// <summary>
        /// 错误消息
        /// </summary>
        Error = 9999
    }
}

using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    /// 自定义接收过滤器(WeicheReceiveFilter)
    /// 接收过滤器(ReceiveFilter)用于将接收到的二进制数据转化成请求实例(RequestInfo)。
    /// 实现一个接收过滤器(ReceiveFilter), 你需要实现接口 IReceiveFilter:
    /// </summary>
    public class ChatReceiveFilter : BeginEndMarkReceiveFilter<IBaseRequestInfo>
    {
        //private BasicRequestInfoParser m_Parser = new BasicRequestInfoParser();
        //private WeicheRequestInfoParser m_Parser = new WeicheRequestInfoParser();
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { 0x24, 0x24 };//$$
        private readonly static byte[] EndMark = new byte[] { 0x0d, 0x0a };//\r\n

        public ChatReceiveFilter()
            : base(BeginMark, EndMark) //传入开始标记和结束标记
        {

        }
        public override IBaseRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            return base.Filter(readBuffer, offset, length, toBeCopied, out rest);
        }
        protected override IBaseRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            //调用解析器解析请求
            IBaseRequestInfo info = ChatRequestInfoParser.Instance.ParseRequestInfo(readBuffer, offset, length);
            if (info == null)
            {
                return NullRequestInfo;
            }
            return info;
        }
    }
}

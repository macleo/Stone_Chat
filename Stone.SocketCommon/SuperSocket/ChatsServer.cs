using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Config;
using SuperSocket.Facility.Protocol;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    /// Description of MyServer.
    /// </summary>
    public class ChatsServer : AppServer<ChatsSession, IBaseRequestInfo>
    {

        /*  =============1、TerminatorReceiveFilter - 结束符协议    ==========    
            与命令行协议类似，一些协议用结束符来确定一个请求.
            例如, 一个协议使用两个字符 "$$" 作为结束符, 于是你可以使用类 "TerminatorReceiveFilterFactory":
         */
        //public WeicheServer()
        //    : base(new TerminatorReceiveFilterFactory("$"))
        //{
        //}
        

        /*  ==========2、CountSpliterReceiveFilter - 固定数量分隔符协议 ===========
            有些协议定义了像这样格式的请求 "#part1#part2#part3#part4#part5#part6#part7#".
            每个请求有7个由 '#' 分隔的部分. 这种协议的实现非常简单:
        public WeicheServer()
            : base(new CountSpliterReceiveFilterFactory((byte)'#', 8)) // 7 parts but 8 separators
        { }*/

        /*  ==========3、FixedSizeReceiveFilter - 固定请求大小的协议   ============ 
            在这种协议之中, 所有请求的大小都是相同的。如果你的每个请求都是有9个字符组成的字符串，如"KILL BILL",
            你应该做的事就是像如下代码这样实现一个接收过滤器(ReceiveFilter):
        
        public WeicheServer()
            : base(new DefaultReceiveFilterFactory<MyReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {
        }
        public class MyReceiveFilter : FixedSizeReceiveFilter<StringRequestInfo>
        {
            public MyReceiveFilter()
                : base(9) //传入固定的请求大小
            {

            }

            protected override StringRequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length, bool toBeCopied)
            {
                //TODO: 通过解析到的数据来构造请求实例，并返回
            }
        }
         */

        /*  4、=============BeginEndMarkReceiveFilter - 带起止符的协议    ==========    
            在这类协议的每个请求之中 都有固定的开始和结束标记。例如, 我有个协议，它的所有消息都遵循这种格式 "!xxxxxxxxxxxxxx$"。
            因此，在这种情况下， "$$" 是开始标记， "\r\n" 是结束标记，于是你的接受过滤器可以定义成这样:
         */
        public ChatsServer()
            : base(new ChatReceiveFilterFactory<ChatReceiveFilter, IBaseRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {
        }

        

        /*  5、=============FixedHeaderReceiveFilter - 头部格式固定并且包含内容长度的协议    ==========    
            这种协议将一个请求定义为两大部分, 第一部分定义了包含第二部分长度等等基础信息. 我们通常称第一部分为头部.
            例如, 我们有一个这样的协议: 头部包含 6 个字节, 前 4 个字节用于存储请求的名字, 后两个字节用于代表请求体的长度:
         
        public WeicheServer()
            : base(new DefaultReceiveFilterFactory<MyReceiveFilter, StringRequestInfo>()) //使用默认的接受过滤器工厂 (DefaultReceiveFilterFactory)
        {
        }
        public class MyReceiveFilter : FixedHeaderReceiveFilter<BinaryRequestInfo>
        {
            public MyReceiveFilter()
                : base(6)
            {}

            protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
            {
                return (int)header[offset + 4] * 256 + (int)header[offset + 5];
            }

            protected override BinaryRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
            {
                return new BinaryRequestInfo(Encoding.UTF8.GetString(header.Array, header.Offset, 4), bodyBuffer.CloneRange(offset, length));
            }
        }
        你需要基于类FixedHeaderReceiveFilter实现你自己的接收过滤器.
        传入父类构造函数的 6 表示头部的长度;
        方法"GetBodyLengthFromHeader(...)" 应该根据接收到的头部返回请求体的长度;
        方法 ResolveRequestInfo(....)" 应该根据你接收到的请求头部和请求体返回你的请求类型的实例.
         */

        //如有需要可以重写这些方法
        //protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        //{
        //    return base.Setup(rootConfig, config);
        //}

        //protected override void OnStartup()
        //{
        //    base.OnStartup();
        //}

        //protected override void OnStopped()
        //{
        //    base.OnStopped();
        //}

        #region 重写方法
        /// <summary>
        /// 服务开始装载
        /// </summary>
        /// <param name="rootConfig"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }
        /// <summary>
        /// 服务启动
        /// </summary>
        protected override void OnStarted()
        {
            Utils.SaveLog("WeicheServer","WeicheServer服务启动");
            base.OnStarted();
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStopped()
        {
            Utils.SaveLog("WeicheServer", "WeicheServer服务停止");
            base.OnStopped();
        }

        /// <summary>
        /// 新的连接
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(ChatsSession session)
        {
            Utils.SaveLog("WeicheServer", "WeicheServer服务新加入的连接:" + session.LocalEndPoint.Address.ToString());
            base.OnNewSessionConnected(session);
        }

        #endregion

        #region 处理事件（如果是配置启动，实现以下事件）
        //在OnStarted注册事件
        //this.NewRequestReceived += WeicheServer_NewRequestReceived;
        //this.NewSessionConnected += WeicheServer_NewSessionConnected;
        //this.SessionClosed += WeicheServer_SessionClosed;
        //private void WeicheServer_NewRequestReceived(WeicheSession session, WeicheRequestInfo requestInfo)
        //{

        //}
        //private void WeicheServer_NewSessionConnected(WeicheSession session)
        //{

        //}
        //private void WeicheServer_SessionClosed(WeicheSession session, CloseReason value)
        //{

        //}
        #endregion
    }
}

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    /// 自定义接收过滤器工厂(ReceiveFilterFactory)
    /// </summary>
    public class ChatReceiveFilterFactory<TReceiveFilter, TRequestInfo> : IReceiveFilterFactory<TRequestInfo>
        where TRequestInfo : IRequestInfo
        where TReceiveFilter : IReceiveFilter<TRequestInfo>, new()
    {
        /// <summary>
        /// Creates the Receive filter.
        /// </summary>
        /// <param name="appServer">The app server.</param>
        /// <param name="appSession">The app session.</param>
        /// <param name="remoteEndPoint">The remote end point.</param>
        /// <returns>
        /// the new created request filer assosiated with this socketSession
        /// </returns>
        public virtual IReceiveFilter<TRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new TReceiveFilter();
        }
    }
}

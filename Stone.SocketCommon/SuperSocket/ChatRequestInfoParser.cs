using Newtonsoft.Json;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.SocketCommon
{
    /// <summary>
    /// 自定义解析器Parser
    /// </summary>
    public class ChatRequestInfoParser : IRequestInfoParser<IBaseRequestInfo>
    {
        /// <summary>
        /// 请求包头
        /// </summary>
        private readonly string RequestHeader = "$$";//2424
        /// <summary>
        /// 请求包尾
        /// </summary>
        private readonly string RequestEnding = "\r\n";//0D0A
        /// <summary>
        /// 默认单例
        /// </summary>
        public static readonly ChatRequestInfoParser Instance = new ChatRequestInfoParser();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChatRequestInfoParser() { }

        #region 解析请求信息
        /// <summary>
        /// 解析请求信息(不用)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IBaseRequestInfo ParseRequestInfo(string source)
        {
            return null;
        }
        /// <summary>
        /// 解析请求信息
        /// </summary>
        /// <param name="readBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public IBaseRequestInfo ParseRequestInfo(byte[] readBuffer, int offset, int length)
        {
            var line = Encoding.UTF8.GetString(readBuffer, offset, length);
            line = line.Substring(0, line.IndexOf(RequestEnding));
            line = line.Replace(RequestHeader, "").Replace(RequestEnding, "");
            string jsonData = Utils.DecodeBase64(line);
            BaseRequestInfo baseInfo = JsonConvert.DeserializeObject<BaseRequestInfo>(jsonData);
            switch (baseInfo.MsgType)
            {
                case MsgType.Text:
                    return JsonConvert.DeserializeObject<TextRequestInfo>(jsonData);
                default:
                    return null;
            }
        }
       
        #endregion
    }
}

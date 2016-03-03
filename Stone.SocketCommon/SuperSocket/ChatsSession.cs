using System;
using System.Threading;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace Stone.SocketCommon
{
	/// <summary>
	/// Description of LightSession.
	/// </summary>
    public class ChatsSession : AppSession<ChatsSession, IBaseRequestInfo>
    {
        
        /// <summary>
        /// Session会话连接的用户名
        /// </summary>
        public string UserName = "";

        /// <summary>
        /// 处理会话连接事件
        /// </summary>
        protected override void OnSessionStarted()
        {
            Utils.SaveLog("WeicheSession", "有新的WeicheSession会话连接");
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInit()
        {
            base.OnInit();
        }
        /// <summary>
        /// 处理未知请求
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(IBaseRequestInfo requestInfo)
        {
            Utils.SaveLog("WeicheSession", "WeicheSession会话->未知请求");
            SessionHelper.SendMessage(this, "请求被拒绝，请重试！");
        }
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            Utils.SaveLog("WeicheSession", "WeicheSession会话异常：" + Convert.ToString(e.Message));
            SessionHelper.SendMessage(this, "-1#服务器异常:" + Convert.ToString(e.Message));
        }
        /// <summary>
        /// 处理会话断开事件
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            Utils.SaveLog("WeicheSession", "WeicheSession会话关闭：" + reason.ToString());
            //此处可添加Session关闭后的一些逻辑片
            base.OnSessionClosed(reason);
        }
    }
}

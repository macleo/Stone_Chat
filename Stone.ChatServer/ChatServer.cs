using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using Stone.SocketCommon;
using System.Net;
using Newtonsoft.Json;
namespace Stone.ChatServer
{
    public partial class ChatServer : Form
    {
        #region 属性
        /// <summary>
        /// 服务器IP地址IP
        /// </summary>
        private string ServerIP;
        /// <summary>
        /// 监听端口
        /// </summary>
        private int Port;
        /// <summary>
        /// 监听客户端连接，承载TCP连接的服务器实例
        /// </summary>
        private ChatsServer appServer;
        /// <summary>
        /// 数据访问对象
        /// </summary>
        private BaseDao baseDao;
        #endregion

        #region 窗体事件
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChatServer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            baseDao = new BaseDao();
            SetServerIPAndPort();
        }
       
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (appServer == null)
            {
                MessageBox.Show("服务未启动！！");
                return;
            }
        }
        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStart_Click(object sender, EventArgs e)
        {
            appServer = new ChatsServer();
            //装载服务配置
            if (!appServer.Setup(ServerIP, Port))
            {
                ShowMsg("装载失败!");
                return;
            }
            //尝试开启服务
            if (!appServer.Start())
            {
                ShowMsg("启动失败!");
                return;
            }
            ShowMsg("服务已启动!");

            //注册会话新建事件处理方法
            appServer.NewSessionConnected += new SessionHandler<ChatsSession>(appServer_NewSessionConnected);
            //注册会话断开事件处理方法
            appServer.SessionClosed += new SessionHandler<ChatsSession, SuperSocket.SocketBase.CloseReason>(appServer_SessionClosed);
            //注册请求处理方法 
            appServer.NewRequestReceived += new RequestHandler<ChatsSession, IBaseRequestInfo>(appServer_RequestHandler);

            this.tbStart.Enabled = false;
            this.tbStop.Enabled = true;
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "服务正在运行，是否退出？", "温馨提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Stop the appServer
                appServer.Stop();
                ShowMsg("\n服务停止!");
                this.tbStart.Enabled = true;
                this.tbStop.Enabled = false;
            }
        }
        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_ClearData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = this.richTextBox1.Text;
            this.richTextBox1.Clear();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        #endregion

        #region 通信处理事件
        /// <summary>
        /// 新事件处理代码中发送欢迎信息给客户端
        /// </summary>
        /// <param name="appSession"></param>
        public void appServer_NewSessionConnected(ChatsSession appSession)
        {
            UpdateConnection();
            ShowMsg("有新的连接,正在接收数据……");
        }
        /// <summary>
        /// 会话断开事件处理代码
        /// </summary>
        /// <param name="appSession"></param>
        public void appServer_SessionClosed(ChatsSession appSession, SuperSocket.SocketBase.CloseReason closeReason)
        {
            ShowMsg(string.Format("用户[{0}]退出登录,原因：{1}", appSession.UserName, closeReason.ToString()));
            UpdateConnection();
        }
        /// <summary>
        /// 请求事件入口
        /// </summary>
        /// <param name="session"></param>
        /// <param name="rInfo"></param>
        private void appServer_RequestHandler(ChatsSession session, IBaseRequestInfo baseInfo)
        {
            StringBuilder sb = new StringBuilder();
            switch (baseInfo.MsgType)
            {
                case MsgType.Text:
                    Text_RequestHandler(session,baseInfo);
                    break;
            }
            UpdateWeicheSession(session);
            UpdateConnection();
        }
        /// <summary>
        /// 文本消息处理
        /// </summary>
        /// <param name="baseInfo"></param>
        public void Text_RequestHandler(ChatsSession session,IBaseRequestInfo baseInfo)
        {
            TextRequestInfo info = (TextRequestInfo)baseInfo;
            session.UserName = info.FromUserName;
            #region 显示请求信息
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("-------------start({0})-----------------\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            sb.Append(string.Format("发送人：{0}\r\n时间：{1}\r\n消息内容：{2}",
                info.FromUserName,info.CreateTime, info.Content));
            sb.Append("\r\n-------------end-----------------\r\n");
            ShowMsg(sb.ToString());

            foreach (ChatsSession s in GetAllChatsSession())
            {
                if (s.UserName != info.FromUserName)
                {
                    SessionHelper.SendMessage(s, JsonConvert.SerializeObject(info));
                }
            }

            #endregion

        }
      
        #endregion

        #region 相关方法
        /// <summary>
        /// 设置IP地址及端口
        /// </summary>
        private void SetServerIPAndPort()
        {
            try
            { 
                //ServerIP = Utils.GetAddressIP();
                if (string.IsNullOrEmpty(ServerIP))
                {
                    ServerIP = ConfigurationManager.AppSettings["ServerIP"].ToString(); //设定IP
                }
                Port = int.Parse(ConfigurationManager.AppSettings["ServerPort"].ToString()); //设定端口
                this.label1.Text = string.Format("IP地址：{0} - Port端口：{1}", ServerIP, Port);
            }
            catch (Exception ex)
            {
                ShowMsg("设置IP地址及端口异常:" + ex.Message);
            }
        }
        /// <summary>
        /// 更新会话(将断开的未能通知到的Session清除)
        /// </summary>
        /// <returns></returns>
        public void UpdateWeicheSession(ChatsSession session)
        {
            List<ChatsSession> list = appServer.GetSessions(s => s.UserName == session.UserName).ToList();
            foreach (ChatsSession s in list)
            {
                if (s.SessionID != session.SessionID)
                {
                    s.Close();
                }
            }
        }
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <returns></returns>
        public ChatsSession GetChatsSession(string userName)
        {
            List<ChatsSession> sessions = appServer.GetSessions(s => s.UserName == userName).ToList();
            if (sessions.Count > 0)
                return sessions[0];
            return null;
        }
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <returns></returns>
        public List<ChatsSession> GetAllChatsSession()
        {
            List<ChatsSession> sessions = appServer.GetAllSessions().ToList();
            return sessions;
        }
        /// <summary>
        /// 显示相关消息
        /// </summary>
        /// <param name="msg"></param>
        private delegate void ShowMsgDelegate(string msg);
        public void ShowMsg(string msg)
        {
            if (richTextBox1.InvokeRequired)
            {
                ShowMsgDelegate d = ShowMsg;
                richTextBox1.Invoke(d, msg);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msg.ToString());
                this.richTextBox1.AppendText(sb.ToString());
            }
        }
        /// <summary>
        /// 更新会话数
        /// </summary>
        /// <param name="msg"></param>
        private delegate void UpdateConnectionDelegate();
        public void UpdateConnection()
        {
            if (this.dataGridView_Connection.InvokeRequired)
            {
                UpdateConnectionDelegate d = UpdateConnection;
                dataGridView_Connection.Invoke(d);
            }
            else
            {
                List<ChatsSession> sessions = appServer.GetAllSessions().ToList();
                this.dataGridView_Connection.Rows.Clear();
                foreach (ChatsSession s in sessions)
                {
                    if (!string.IsNullOrEmpty(s.UserName))
                    {
                        int index = this.dataGridView_Connection.Rows.Add();
                        this.dataGridView_Connection.Rows[index].Cells[1].Value = s.UserName;
                        this.dataGridView_Connection.Rows[index].Cells[2].Value = s.SessionID;
                        this.dataGridView_Connection.Rows[index].Cells[3].Value = s.RemoteEndPoint.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 处理指令数据（两个字节之间加空格）
        /// </summary>
        /// <returns></returns>
        public string DealResponseData(string s)
        {
            StringBuilder sb = new StringBuilder();
            char[] data = s.ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i]);
                if (i % 2 == 1)
                    sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
        #endregion

    }
}

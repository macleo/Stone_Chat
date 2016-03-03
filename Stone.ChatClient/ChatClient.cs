using Newtonsoft.Json;
using Stone.SocketCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Stone.ChatClient
{
    public partial class ChatClient : Form
    {
        /// <summary>
        /// socket对象
        /// </summary>
        private SocketUtil socketServer;
        /// <summary>
        /// 构造
        /// </summary>
        public ChatClient()
        {
            InitializeComponent();
        }

        #region 窗体事件方法
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeicheServer_Load(object sender, EventArgs e)
        {
            socketServer = new SocketUtil();
            socketServer.ReceiveSuccessed += AddChatsToList;
        }
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Send_Click(object sender, EventArgs e)
        {
            if (socketServer == null)
            {
                return;
            }
            TextRequestInfo info = new TextRequestInfo();
            info.FromUserName = this.txtUserName.Text;
            info.ToUserName = "All";
            info.Content = this.txtContent.Text;
            info.MsgType = MsgType.Text;
            socketServer.SendMessage(Utils.EncodeBase64(JsonConvert.SerializeObject(info)));
            AddChatsToList(info);
            this.txtContent.Text = "";
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Trim() == "")
            {
                MessageBox.Show(this,"请输入聊天昵称！");
                return;
            }
            txtUserName.Enabled = false;
            this.btnLogin.Enabled = false;
            this.buttom_Send.Enabled = true;
            if (!socketServer.ConnectServer())
            {
                MessageBox.Show(this, "登录失败！");
                txtUserName.Enabled = true;
                this.btnLogin.Enabled = true;
                this.buttom_Send.Enabled = false;
            }
            else
            {
                MessageBox.Show(this, "登录成功！");
                this.txtContent.Focus();
            }
        }
        /// <summary>
        /// 消息框文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbMsgList_TextChanged(object sender, EventArgs e)
        {
            rtbMsgList.SelectionStart = rtbMsgList.TextLength;
            // Scrolls the contents of the control to the current caret position.
            rtbMsgList.ScrollToCaret();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeicheTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socketServer != null)
            {
                socketServer.ReleaseResouce();
            }
            Application.Exit();
        }
        #endregion

        #region ==相关方法==
        private delegate void AddItemToListBoxDelegate(IBaseRequestInfo info);
        /// <summary>
        /// 在listBox_Chats消息记录中追加信息
        /// </summary>
        /// <param name="str">要追加的信息</param>
        private void AddChatsToList(IBaseRequestInfo baseInfo)
        {
            try
            {
                if (rtbMsgList.InvokeRequired)
                {
                    AddItemToListBoxDelegate d = AddChatsToList;
                    rtbMsgList.Invoke(d, baseInfo);
                }
                else
                {
                    switch (baseInfo.MsgType)
                    {
                        case MsgType.Text:
                            TextRequestInfo textInfo = (TextRequestInfo)baseInfo;
                            rtbMsgList.SelectionStart = rtbMsgList.Text.Length;//设置插入符位置为文本框末
                            if (this.txtUserName.Text != textInfo.FromUserName)
                            {
                                rtbMsgList.SelectionColor = Color.Blue;//设置文本颜色
                            }
                            else
                            {
                                rtbMsgList.SelectionColor = Color.Green;//设置文本颜色
                            }
                            rtbMsgList.AppendText(textInfo.FromUserName + "(" + Utils.GetDateTime() + ")\r\n");
                            rtbMsgList.SelectionStart = rtbMsgList.Text.Length;//设置插入符位置为文本框末
                            rtbMsgList.SelectionColor = Color.Black;//设置文本颜色
                            rtbMsgList.AppendText(textInfo.Content + "\r\n");
                            break;
                        case MsgType.Error:
                            ErrorRequestInfo errorInfo = (ErrorRequestInfo)baseInfo;
                            MessageBox.Show(this, errorInfo.Content);
                            txtUserName.Enabled = true;
                            this.btnLogin.Enabled = true;
                            this.buttom_Send.Enabled = false;
                            break;
                    }
                }
            }
            catch { }
        }
       
        #endregion

       

    }
}

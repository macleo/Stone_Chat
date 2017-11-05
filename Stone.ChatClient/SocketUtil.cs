using Newtonsoft.Json;
using Stone.SocketCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Stone.ChatClient
{
    public delegate void ReceiveSuccessedDelegate(IBaseRequestInfo info);
    /// <summary>
    /// Socket通信类
    /// </summary>
    public class SocketUtil
    {
        public ReceiveSuccessedDelegate ReceiveSuccessed = null;

        #region 属性
        /// <summary>
        /// 服务器请求包头
        /// </summary>
        private string RequestHeader = "$$";//2424
        /// <summary>
        /// 服务器请求包尾
        /// </summary>
        private string RequestEnding = "\r\n";//0D0A
        /// <summary>
        /// 服务器IP地址IP
        /// </summary>
        private string ServerIP
        {
            get { return Utils.GetConfig("ServerIP"); }
        }
        /// <summary>
        /// 监听端口
        /// </summary>
        private int Port
        {
            get { return Convert.ToInt32(Utils.GetConfig("ServerPort")); }
        }
        /// <summary>
        /// 退出标识
        /// </summary>
        private bool IsExit = false;
        /// <summary>
        /// 网络流
        /// </summary>
        private NetworkStream networkStream;
        /// <summary>
        /// 读流
        /// </summary>
        private StreamReader streamReader;
        /// <summary>
        /// 写流
        /// </summary>
        private StreamWriter streamWriter;
        /// <summary>
        /// 侦听TCP网络客户端连接对象
        /// </summary>
        private TcpClient socketClient;
        /// <summary>
        /// 接收信息线程
        /// </summary>
        private Thread receiveThread;
        /// <summary>
        /// Socket实例
        /// </summary>
        public TcpClient SocketClient
        {
            get
            {
                if (socketClient == null )
                {
                    ReleaseResouce();
                    ConnectServer();
                }
                return socketClient;
            }
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        public bool ConnectServer()
        {
            try
            {
                socketClient = new TcpClient(ServerIP, Port);
                // 创建networkStream对象通过网络套节字来接受和发送数据  
                networkStream = socketClient.GetStream();
                // 从当前数据流中读取一行字符，返回值是字符串  
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                receiveThread = new Thread(new ThreadStart(ReceiveData));
                receiveThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                Utils.SaveLog("SocketClient-Connection", "连接失败，原因：" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 处理接收的客户端信息
        /// </summary>
        /// <param name="userState">客户端信息</param>
        private void ReceiveData()
        {
            string receiveData = "";
            while (IsExit == false)
            {
                try
                {
                    receiveData = streamReader.ReadLine().Replace("@","").Replace("\r\n","");
                    //从网络流中读出字符串，此方法会自动判断字符串长度前缀
                    //receiveData = _BinaryReader.ReadString();
                    receiveData = Utils.DecodeBase64(receiveData);
                    if (ReceiveSuccessed != null)
                    {
                        ReceiveSuccessed(JsonConvert.DeserializeObject<TextRequestInfo>(receiveData));
                    }
                    Utils.SaveLog("receiveData", receiveData);
                }
                catch (Exception ex)
                {
                    //if (IsExit == false)
                    {
                        Utils.SaveLog("断开与服务器的连接", ex.Message);
                    }
                    Utils.SaveLog("Client接收数据异常", ex.Message);
                    ErrorRequestInfo info = new ErrorRequestInfo();
                    info.Content = "断线啦，请重连！";
                    ReceiveSuccessed(info);
                    break;
                }
            }
            Utils.SaveLog("receiveData:", "服务器关闭:" + receiveData);
        }
        /// <summary>
        /// 向服务端发送消息
        /// 发送命令。格式：$$【内容】\r\n
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            if (SocketClient == null)
                return;
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                Utils.SaveLog("SendMessage",message);
                streamWriter.Write(RequestHeader + message + RequestEnding);
                streamWriter.Flush();
            }
            catch (Exception ex)
            {
                Utils.SaveLog("SendMessage", "发送失败:" + ex.Message);
            }
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void ReleaseResouce()
        {
            if (socketClient != null)
            {
                networkStream.Close();
                streamReader.Close();
                streamWriter.Close();
                networkStream.Dispose();
                streamReader.Dispose();
                streamWriter.Dispose();
                if (receiveThread.IsAlive)
                {
                    receiveThread.Abort();
                }
                socketClient.Close();
            }
        } 
        #endregion
    }
}

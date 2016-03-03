using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace Stone.SocketCommon
{
    public class Utils
    {

        #region ========系统文件日志========
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strContent"></param>
        public static void SaveLog(string strTitle, string strContent)
        {
            try
            {
                string Path = AppDomain.CurrentDomain.BaseDirectory + "Logs/" + DateTime.Now.ToString("yyyyMM") + "/";
                string FilePath = Path + DateTime.Now.ToString("dd") + "_Log.txt";
                if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
                if (!File.Exists(FilePath))
                {
                    FileStream FsCreate = new FileStream(FilePath, FileMode.Create);
                    FsCreate.Close();
                    FsCreate.Dispose();
                }
                FileStream FsWrite = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                StreamWriter SwWrite = new StreamWriter(FsWrite);
                SwWrite.WriteLine(string.Format("{0}{1}[{2}]{3}", "--------------------------------", strTitle, DateTime.Now.ToString("HH:mm"), "--------------------------------"));
                SwWrite.Write(strContent);
                SwWrite.WriteLine("\r\n");
                SwWrite.WriteLine(" ");
                SwWrite.Flush();
                SwWrite.Close();
            }
            catch { }
        }        
        #endregion

        #region ========字符相关=========
        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string content, string split)
        {
            if (!string.IsNullOrEmpty(content))
            {
                if (content.IndexOf(split) < 0)
                {
                    string[] tmp = { content };
                    return tmp;
                }
                return Regex.Split(content, Regex.Escape(split), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region ========其他方法========
        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            try { return ConfigurationManager.AppSettings[key].ToString(); }
            catch { return ""; }
        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string strHostName = Dns.GetHostName();   //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP
            string userIP = "";
            foreach (IPAddress ip in ipEntry.AddressList)
            {
                if (Regex.IsMatch(ip.ToString(), "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$"))
                {
                    userIP = ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        #endregion

        #region ========Base64编码========
        /// <summary>
        /// base64编码(默认utf-8)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeBase64( string str)
        {
            return EncodeBase64(Encoding.GetEncoding("utf-8"), str);
        }
        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="code_type">编码类型</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeBase64(string codeType, string str)
        {
            return EncodeBase64(Encoding.GetEncoding(codeType), str);
        }
        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="code_type">编码类型</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encoding, string str)
        {
            string encode = "";
            byte[] bytes = encoding.GetBytes(str);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = str;
            }
            return encode;
        }
        #endregion

        #region ========Base64解码========
        /// <summary>
        /// base64解码(默认utf-8)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeBase64(string str)
        {
            return DecodeBase64(Encoding.GetEncoding("utf-8"), str);
        }
        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="code_type">编码类型</param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string DecodeBase64(string codeType, string str)
        {
            return DecodeBase64(Encoding.GetEncoding(codeType), str);
        }
        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="encoding">编码类型</param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeBase64(Encoding encoding, string str)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(str);
            try
            {
                decode = encoding.GetString(bytes);
            }
            catch
            {
                decode = str;
            }
            return decode;
        }
        #endregion

    }
}


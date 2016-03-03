using Stone.SocketCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Stone.ChatServer.Properties;

namespace Stone.ChatServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitDatabase();
            Application.Run(new ChatServer());
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static int InitDatabase()
        {
            try
            {
                if (!Directory.Exists(SQLiteHelper.DataFullPath))
                {
                    Directory.CreateDirectory(SQLiteHelper.DataFullPath);
                }

                if (!File.Exists(SQLiteHelper.DataFilePath))
                {
                    SQLiteHelper.CreateDataBase();
                    SQLiteHelper.ExecuteNonQuery(SQLiteHelper.DataSource, CommandType.Text, Resources.sql_sqlite);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Utils.SaveLog("InitDatabase", ex.Message);
                return -1;
            }
        }
    }
}

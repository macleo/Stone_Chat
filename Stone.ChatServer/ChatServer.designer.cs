namespace Stone.ChatServer
{
    partial class ChatServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatServer));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Connection = new System.Windows.Forms.DataGridView();
            this.Column_TargetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TargetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SessionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel_ClearData = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Connection)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(596, 153);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(340, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP：192.168.0.34     Port:8000";
            // 
            // dataGridView_Connection
            // 
            this.dataGridView_Connection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Connection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_TargetType,
            this.Column_TargetID,
            this.Column_SessionID,
            this.Column_IP});
            this.dataGridView_Connection.Location = new System.Drawing.Point(15, 304);
            this.dataGridView_Connection.Name = "dataGridView_Connection";
            this.dataGridView_Connection.RowTemplate.Height = 23;
            this.dataGridView_Connection.Size = new System.Drawing.Size(602, 133);
            this.dataGridView_Connection.TabIndex = 8;
            // 
            // Column_TargetType
            // 
            this.Column_TargetType.HeaderText = "类型";
            this.Column_TargetType.Name = "Column_TargetType";
            this.Column_TargetType.Width = 60;
            // 
            // Column_TargetID
            // 
            this.Column_TargetID.HeaderText = "会员卡/设备号";
            this.Column_TargetID.Name = "Column_TargetID";
            this.Column_TargetID.Width = 150;
            // 
            // Column_SessionID
            // 
            this.Column_SessionID.HeaderText = "会话ID";
            this.Column_SessionID.Name = "Column_SessionID";
            this.Column_SessionID.Width = 210;
            // 
            // Column_IP
            // 
            this.Column_IP.HeaderText = "IP地址";
            this.Column_IP.Name = "Column_IP";
            this.Column_IP.Width = 130;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbStart,
            this.toolStripSeparator1,
            this.tbStop,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(623, 39);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbStart
            // 
            this.tbStart.Image = global::Stone.ChatServer.Properties.Resources.start;
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(68, 36);
            this.tbStart.Text = "启动";
            this.tbStart.ToolTipText = "启动短信服务";
            this.tbStart.Click += new System.EventHandler(this.tbStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tbStop
            // 
            this.tbStop.Enabled = false;
            this.tbStop.Image = global::Stone.ChatServer.Properties.Resources.stop;
            this.tbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStop.Name = "tbStop";
            this.tbStop.Size = new System.Drawing.Size(68, 36);
            this.tbStop.Text = "停止";
            this.tbStop.ToolTipText = "停止短信服务";
            this.tbStop.Click += new System.EventHandler(this.tbStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Stone.ChatServer.Properties.Resources.exit;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton3.Text = "退出";
            this.toolStripButton3.ToolTipText = "退出系统";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel_ClearData);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 173);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "收发数据";
            // 
            // linkLabel_ClearData
            // 
            this.linkLabel_ClearData.AutoSize = true;
            this.linkLabel_ClearData.Location = new System.Drawing.Point(530, 0);
            this.linkLabel_ClearData.Name = "linkLabel_ClearData";
            this.linkLabel_ClearData.Size = new System.Drawing.Size(53, 12);
            this.linkLabel_ClearData.TabIndex = 1;
            this.linkLabel_ClearData.TabStop = true;
            this.linkLabel_ClearData.Text = "清空数据";
            this.linkLabel_ClearData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ClearData_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "群发消息：";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.ForeColor = System.Drawing.Color.Green;
            this.btnSend.Location = new System.Drawing.Point(427, 22);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 26);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(91, 25);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(309, 21);
            this.tbData.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbData);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(15, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 65);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "指令操作";
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_Connection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChatServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息转发服务器（v1.0）";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Connection)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Connection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TargetType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TargetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SessionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IP;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel_ClearData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}


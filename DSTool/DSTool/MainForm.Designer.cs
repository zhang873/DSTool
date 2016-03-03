namespace DSTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.btn_flush = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.rbtn_usb = new System.Windows.Forms.RadioButton();
            this.rbtn_net = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ipaddr = new System.Windows.Forms.TextBox();
            this.lab_version = new System.Windows.Forms.Label();
            this.lab_linkState = new System.Windows.Forms.Label();
            this.lab_netState = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_ip = new System.Windows.Forms.Button();
            this.btn_reboot = new System.Windows.Forms.Button();
            this.btn_screencap = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_uninstall = new System.Windows.Forms.Button();
            this.btn_config = new System.Windows.Forms.Button();
            this.btn_install = new System.Windows.Forms.Button();
            this.btn_state_analysis = new System.Windows.Forms.Button();
            this.btn_app_version = new System.Windows.Forms.Button();
            this.btn_trim = new System.Windows.Forms.Button();
            this.btn_getLog = new System.Windows.Forms.Button();
            this.pb_screencap = new System.Windows.Forms.PictureBox();
            this.tb_info = new System.Windows.Forms.TextBox();
            this.lab_screenTime = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lv_search_result = new System.Windows.Forms.ListView();
            this.ch_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_start_ip = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_screencap)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.btn_flush);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_ipaddr);
            this.groupBox1.Controls.Add(this.lab_version);
            this.groupBox1.Controls.Add(this.lab_linkState);
            this.groupBox1.Controls.Add(this.lab_netState);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(286, 34);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(52, 26);
            this.button9.TabIndex = 3;
            this.button9.Text = "搜索";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            // 
            // btn_flush
            // 
            this.btn_flush.Enabled = false;
            this.btn_flush.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_flush.Location = new System.Drawing.Point(601, 105);
            this.btn_flush.Name = "btn_flush";
            this.btn_flush.Size = new System.Drawing.Size(75, 51);
            this.btn_flush.TabIndex = 1;
            this.btn_flush.Text = "刷新";
            this.btn_flush.UseVisualStyleBackColor = true;
            this.btn_flush.Click += new System.EventHandler(this.btn_flush_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "ROM版本：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接状况：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "终端IP地址";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_disconnect);
            this.panel2.Controls.Add(this.btn_connect);
            this.panel2.Controls.Add(this.rbtn_usb);
            this.panel2.Controls.Add(this.rbtn_net);
            this.panel2.Location = new System.Drawing.Point(354, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 57);
            this.panel2.TabIndex = 2;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Enabled = false;
            this.btn_disconnect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_disconnect.Location = new System.Drawing.Point(269, 11);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(53, 36);
            this.btn_disconnect.TabIndex = 1;
            this.btn_disconnect.Text = "断开";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Enabled = false;
            this.btn_connect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_connect.Location = new System.Drawing.Point(210, 11);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(53, 36);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // rbtn_usb
            // 
            this.rbtn_usb.AutoSize = true;
            this.rbtn_usb.Checked = true;
            this.rbtn_usb.Location = new System.Drawing.Point(15, 20);
            this.rbtn_usb.Name = "rbtn_usb";
            this.rbtn_usb.Size = new System.Drawing.Size(82, 20);
            this.rbtn_usb.TabIndex = 0;
            this.rbtn_usb.TabStop = true;
            this.rbtn_usb.Text = "USB连接";
            this.rbtn_usb.UseVisualStyleBackColor = true;
            this.rbtn_usb.CheckedChanged += new System.EventHandler(this.rbtn_usb_CheckedChanged);
            // 
            // rbtn_net
            // 
            this.rbtn_net.AutoSize = true;
            this.rbtn_net.Location = new System.Drawing.Point(103, 20);
            this.rbtn_net.Name = "rbtn_net";
            this.rbtn_net.Size = new System.Drawing.Size(90, 20);
            this.rbtn_net.TabIndex = 0;
            this.rbtn_net.TabStop = true;
            this.rbtn_net.Text = "网络连接";
            this.rbtn_net.UseVisualStyleBackColor = true;
            this.rbtn_net.CheckedChanged += new System.EventHandler(this.rbtn_net_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "网络状况：";
            // 
            // tb_ipaddr
            // 
            this.tb_ipaddr.Enabled = false;
            this.tb_ipaddr.Location = new System.Drawing.Point(114, 34);
            this.tb_ipaddr.Name = "tb_ipaddr";
            this.tb_ipaddr.Size = new System.Drawing.Size(156, 26);
            this.tb_ipaddr.TabIndex = 1;
            this.tb_ipaddr.Text = "192.168.1.122";
            // 
            // lab_version
            // 
            this.lab_version.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_version.ForeColor = System.Drawing.Color.Green;
            this.lab_version.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_version.Location = new System.Drawing.Point(108, 149);
            this.lab_version.Name = "lab_version";
            this.lab_version.Size = new System.Drawing.Size(473, 30);
            this.lab_version.TabIndex = 1;
            this.lab_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_linkState
            // 
            this.lab_linkState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_linkState.ForeColor = System.Drawing.Color.Green;
            this.lab_linkState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_linkState.Location = new System.Drawing.Point(108, 114);
            this.lab_linkState.Name = "lab_linkState";
            this.lab_linkState.Size = new System.Drawing.Size(473, 30);
            this.lab_linkState.TabIndex = 1;
            this.lab_linkState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_netState
            // 
            this.lab_netState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_netState.ForeColor = System.Drawing.Color.Green;
            this.lab_netState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_netState.Location = new System.Drawing.Point(108, 80);
            this.lab_netState.Name = "lab_netState";
            this.lab_netState.Size = new System.Drawing.Size(473, 30);
            this.lab_netState.TabIndex = 1;
            this.lab_netState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ip);
            this.groupBox2.Controls.Add(this.btn_reboot);
            this.groupBox2.Controls.Add(this.btn_screencap);
            this.groupBox2.Controls.Add(this.btn_stop);
            this.groupBox2.Controls.Add(this.btn_start);
            this.groupBox2.Controls.Add(this.btn_uninstall);
            this.groupBox2.Controls.Add(this.btn_config);
            this.groupBox2.Controls.Add(this.btn_install);
            this.groupBox2.Controls.Add(this.btn_state_analysis);
            this.groupBox2.Controls.Add(this.btn_app_version);
            this.groupBox2.Controls.Add(this.btn_trim);
            this.groupBox2.Controls.Add(this.btn_getLog);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(23, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 169);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制";
            // 
            // btn_ip
            // 
            this.btn_ip.Enabled = false;
            this.btn_ip.Location = new System.Drawing.Point(290, 34);
            this.btn_ip.Name = "btn_ip";
            this.btn_ip.Size = new System.Drawing.Size(85, 36);
            this.btn_ip.TabIndex = 0;
            this.btn_ip.Text = "IP设置";
            this.btn_ip.UseVisualStyleBackColor = true;
            this.btn_ip.Click += new System.EventHandler(this.btn_ip_Click);
            // 
            // btn_reboot
            // 
            this.btn_reboot.Enabled = false;
            this.btn_reboot.Location = new System.Drawing.Point(199, 34);
            this.btn_reboot.Name = "btn_reboot";
            this.btn_reboot.Size = new System.Drawing.Size(85, 36);
            this.btn_reboot.TabIndex = 0;
            this.btn_reboot.Text = "重启";
            this.btn_reboot.UseVisualStyleBackColor = true;
            this.btn_reboot.Click += new System.EventHandler(this.btn_reboot_Click);
            // 
            // btn_screencap
            // 
            this.btn_screencap.Enabled = false;
            this.btn_screencap.Location = new System.Drawing.Point(108, 34);
            this.btn_screencap.Name = "btn_screencap";
            this.btn_screencap.Size = new System.Drawing.Size(85, 36);
            this.btn_screencap.TabIndex = 0;
            this.btn_screencap.Text = "截屏";
            this.btn_screencap.UseVisualStyleBackColor = true;
            this.btn_screencap.Click += new System.EventHandler(this.btn_screencap_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(290, 81);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(85, 36);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "关闭公告";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(199, 81);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(85, 36);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "启动公告";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_uninstall
            // 
            this.btn_uninstall.Enabled = false;
            this.btn_uninstall.Location = new System.Drawing.Point(108, 81);
            this.btn_uninstall.Name = "btn_uninstall";
            this.btn_uninstall.Size = new System.Drawing.Size(85, 36);
            this.btn_uninstall.TabIndex = 0;
            this.btn_uninstall.Text = "卸载公告";
            this.btn_uninstall.UseVisualStyleBackColor = true;
            this.btn_uninstall.Click += new System.EventHandler(this.btn_uninstall_Click);
            // 
            // btn_config
            // 
            this.btn_config.Enabled = false;
            this.btn_config.Location = new System.Drawing.Point(17, 123);
            this.btn_config.Name = "btn_config";
            this.btn_config.Size = new System.Drawing.Size(85, 36);
            this.btn_config.TabIndex = 0;
            this.btn_config.Text = "配置信息";
            this.btn_config.UseVisualStyleBackColor = true;
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // btn_install
            // 
            this.btn_install.Enabled = false;
            this.btn_install.Location = new System.Drawing.Point(17, 81);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(85, 36);
            this.btn_install.TabIndex = 0;
            this.btn_install.Text = "安装公告";
            this.btn_install.UseVisualStyleBackColor = true;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // btn_state_analysis
            // 
            this.btn_state_analysis.Enabled = false;
            this.btn_state_analysis.Location = new System.Drawing.Point(290, 123);
            this.btn_state_analysis.Name = "btn_state_analysis";
            this.btn_state_analysis.Size = new System.Drawing.Size(85, 36);
            this.btn_state_analysis.TabIndex = 0;
            this.btn_state_analysis.Text = "状态分析";
            this.btn_state_analysis.UseVisualStyleBackColor = true;
            this.btn_state_analysis.Visible = false;
            // 
            // btn_app_version
            // 
            this.btn_app_version.Enabled = false;
            this.btn_app_version.Location = new System.Drawing.Point(108, 123);
            this.btn_app_version.Name = "btn_app_version";
            this.btn_app_version.Size = new System.Drawing.Size(85, 36);
            this.btn_app_version.TabIndex = 0;
            this.btn_app_version.Text = "版本信息";
            this.btn_app_version.UseVisualStyleBackColor = true;
            this.btn_app_version.Click += new System.EventHandler(this.btn_app_version_Click);
            // 
            // btn_trim
            // 
            this.btn_trim.Enabled = false;
            this.btn_trim.Location = new System.Drawing.Point(199, 123);
            this.btn_trim.Name = "btn_trim";
            this.btn_trim.Size = new System.Drawing.Size(85, 36);
            this.btn_trim.TabIndex = 0;
            this.btn_trim.Text = "最大切边";
            this.btn_trim.UseVisualStyleBackColor = true;
            this.btn_trim.Click += new System.EventHandler(this.btn_trim_Click);
            // 
            // btn_getLog
            // 
            this.btn_getLog.Enabled = false;
            this.btn_getLog.Location = new System.Drawing.Point(17, 34);
            this.btn_getLog.Name = "btn_getLog";
            this.btn_getLog.Size = new System.Drawing.Size(85, 36);
            this.btn_getLog.TabIndex = 0;
            this.btn_getLog.Text = "获取日志";
            this.btn_getLog.UseVisualStyleBackColor = true;
            this.btn_getLog.Click += new System.EventHandler(this.btn_getLog_Click);
            // 
            // pb_screencap
            // 
            this.pb_screencap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_screencap.Location = new System.Drawing.Point(437, 232);
            this.pb_screencap.Name = "pb_screencap";
            this.pb_screencap.Size = new System.Drawing.Size(280, 158);
            this.pb_screencap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_screencap.TabIndex = 3;
            this.pb_screencap.TabStop = false;
            // 
            // tb_info
            // 
            this.tb_info.Location = new System.Drawing.Point(23, 396);
            this.tb_info.Multiline = true;
            this.tb_info.Name = "tb_info";
            this.tb_info.ReadOnly = true;
            this.tb_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_info.Size = new System.Drawing.Size(694, 235);
            this.tb_info.TabIndex = 4;
            // 
            // lab_screenTime
            // 
            this.lab_screenTime.AutoSize = true;
            this.lab_screenTime.BackColor = System.Drawing.Color.Transparent;
            this.lab_screenTime.Location = new System.Drawing.Point(448, 242);
            this.lab_screenTime.Name = "lab_screenTime";
            this.lab_screenTime.Size = new System.Drawing.Size(41, 12);
            this.lab_screenTime.TabIndex = 1;
            this.lab_screenTime.Text = "无截屏";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "V0.2.0";
            // 
            // lv_search_result
            // 
            this.lv_search_result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ip});
            this.lv_search_result.FullRowSelect = true;
            this.lv_search_result.Location = new System.Drawing.Point(9, 110);
            this.lv_search_result.Name = "lv_search_result";
            this.lv_search_result.Size = new System.Drawing.Size(174, 503);
            this.lv_search_result.TabIndex = 7;
            this.lv_search_result.UseCompatibleStateImageBehavior = false;
            this.lv_search_result.View = System.Windows.Forms.View.Details;
            this.lv_search_result.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_search_result_MouseClick);
            // 
            // ch_ip
            // 
            this.ch_ip.Text = "IP地址";
            this.ch_ip.Width = 129;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lv_search_result);
            this.groupBox3.Controls.Add(this.btn_search);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tb_start_ip);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox3.Location = new System.Drawing.Point(723, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 619);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "搜索终端";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(9, 71);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(174, 33);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "开始扫描";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "搜索网段";
            // 
            // tb_start_ip
            // 
            this.tb_start_ip.Location = new System.Drawing.Point(84, 34);
            this.tb_start_ip.Name = "tb_start_ip";
            this.tb_start_ip.Size = new System.Drawing.Size(99, 26);
            this.tb_start_ip.TabIndex = 0;
            this.tb_start_ip.Text = "192.168.1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lab_screenTime);
            this.Controls.Add(this.tb_info);
            this.Controls.Add(this.pb_screencap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公告配置工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_screencap)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ipaddr;
        private System.Windows.Forms.RadioButton rbtn_net;
        private System.Windows.Forms.RadioButton rbtn_usb;
        private System.Windows.Forms.Label lab_netState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_linkState;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_flush;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_getLog;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_version;
        private System.Windows.Forms.Button btn_reboot;
        private System.Windows.Forms.Button btn_screencap;
        private System.Windows.Forms.PictureBox pb_screencap;
        private System.Windows.Forms.TextBox tb_info;
        private System.Windows.Forms.Label lab_screenTime;
        private System.Windows.Forms.Button btn_trim;
        private System.Windows.Forms.Button btn_ip;
        private System.Windows.Forms.Button btn_state_analysis;
        private System.Windows.Forms.Button btn_uninstall;
        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_config;
        private System.Windows.Forms.Button btn_app_version;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView lv_search_result;
        private System.Windows.Forms.ColumnHeader ch_ip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_start_ip;
    }
}


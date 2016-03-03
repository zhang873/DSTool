using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Xml.Serialization;
using System.Collections;

namespace DSTool
{
    public partial class MainForm : Form
    {
        //private AdbState mStatus;

        private Thread GetLogThread;
        private Thread ServerStartThread;
        private Thread RebootThread;
        private Thread ScreenCapThread;
        private Thread InstallThread;
        private Thread UninstallThread;
        //private Thread StartAPPThread;
        //private Thread StopAPPThread;
        private Thread SearchNetworkThread;

        private Form mInfoForm = null;

        private AdbManager mAdbManager;

        private Configuration mConfig;

        public MainForm()
        {
            InitializeComponent();

            mAdbManager = new AdbManager();

            mConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (mConfig.AppSettings.Settings.AllKeys.Contains("ipaddr") == false)
            {
                mConfig.AppSettings.Settings.Add("ipaddr", "192.168.1.1");
            }

            if (mConfig.AppSettings.Settings.AllKeys.Contains("usb_check") == false)
            {
                mConfig.AppSettings.Settings.Add("usb_check", "false");
            }

            if (mConfig.AppSettings.Settings.AllKeys.Contains("search_start_ip") == false)
            {
                mConfig.AppSettings.Settings.Add("search_start_ip", "192.168.1");
            }

            tb_ipaddr.Text = mConfig.AppSettings.Settings["ipaddr"].Value;
            tb_start_ip.Text = mConfig.AppSettings.Settings["search_start_ip"].Value;
            bool use_usb = mConfig.AppSettings.Settings["usb_check"].Value.Equals("true") == true ? true : false;
            if (use_usb == true)
            {
                rbtn_usb.Checked = true;
                rbtn_net.Checked = false;
            }
            else
            {
                rbtn_usb.Checked = false;
                rbtn_net.Checked = true;
            }

            Common.status = Common.AdbState.NONE;
            UIUpdate(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServerStartThread = new Thread(new ThreadStart(ServerStart));
            ServerStartThread.Start();

            mInfoForm = new InfoForm("程序启动中，请稍候...");
            mInfoForm.ShowDialog();
        }

        private void UIUpdate(bool inThread)
        {
            if (inThread == true)
            {
                switch (Common.status)
                {
                    case Common.AdbState.NONE:
                        Invoke(new Action(() =>
                        {
                            btn_connect.Enabled = false;
                            btn_disconnect.Enabled = false;
                            btn_flush.Enabled = false;
                            btn_getLog.Enabled = false;
                            btn_reboot.Enabled = false;
                            btn_screencap.Enabled = false;
                            btn_ip.Enabled = false;
                            btn_install.Enabled = false;
                            btn_uninstall.Enabled = false;
                            btn_start.Enabled = false;
                            btn_stop.Enabled = false;
                            btn_config.Enabled = false;
                            btn_trim.Enabled = false;
                            btn_state_analysis.Enabled = false;
                            btn_app_version.Enabled = false;
                            btn_trim.Enabled = false;
                        }));

                        break;
                    case Common.AdbState.STARTED:
                        Invoke(new Action(() =>
                        {
                            btn_connect.Enabled = true;
                            btn_disconnect.Enabled = true;
                            btn_flush.Enabled = true;
                            btn_getLog.Enabled = false;
                            btn_reboot.Enabled = false;
                            btn_screencap.Enabled = false;
                            btn_ip.Enabled = false;
                            btn_install.Enabled = false;
                            btn_uninstall.Enabled = false;
                            btn_start.Enabled = false;
                            btn_stop.Enabled = false;
                            btn_config.Enabled = false;
                            btn_trim.Enabled = false;
                            btn_state_analysis.Enabled = false;
                            btn_app_version.Enabled = false;
                            btn_trim.Enabled = false;
                        }));
                        break;
                    case Common.AdbState.CONNECTED:
                        Invoke(new Action(() =>
                        {
                            btn_connect.Enabled = true;
                            btn_disconnect.Enabled = true;
                            btn_flush.Enabled = true;
                            btn_getLog.Enabled = true;
                            btn_reboot.Enabled = true;
                            btn_screencap.Enabled = true;
                            btn_ip.Enabled = true;
                            btn_install.Enabled = true;
                            btn_uninstall.Enabled = true;
                            btn_start.Enabled = true;
                            btn_stop.Enabled = true;
                            btn_config.Enabled = true;
                            btn_trim.Enabled = true;
                            btn_state_analysis.Enabled = true;
                            btn_app_version.Enabled = true;
                            btn_trim.Enabled = true;
                        }));
                        break;
                }
            }
            else
            {
                switch (Common.status)
                {
                    case Common.AdbState.NONE:

                        btn_connect.Enabled = false;
                        btn_disconnect.Enabled = false;
                        btn_flush.Enabled = false;
                        btn_getLog.Enabled = false;
                        btn_reboot.Enabled = false;
                        btn_screencap.Enabled = false;
                        btn_ip.Enabled = false;

                        break;
                    case Common.AdbState.STARTED:

                        btn_connect.Enabled = true;
                        btn_disconnect.Enabled = true;
                        btn_flush.Enabled = true;
                        btn_getLog.Enabled = false;
                        btn_reboot.Enabled = false;
                        btn_screencap.Enabled = false;
                        btn_ip.Enabled = false;

                        break;
                    case Common.AdbState.CONNECTED:

                        btn_connect.Enabled = true;
                        btn_disconnect.Enabled = true;
                        btn_flush.Enabled = true;
                        btn_getLog.Enabled = true;
                        btn_reboot.Enabled = true;
                        btn_screencap.Enabled = true;
                        btn_ip.Enabled = true;

                        break;
                }
            }
        }

        private void ServerStart()
        {
            try
            {
                //Invoke(new Action(() => { tssl_statusText.Text = "ADB Server启动中..."; }));

                bool ret = mAdbManager.AdbServerReStart();

                UIUpdate(true);

                if (ret == true)
                {
                    //Invoke(new Action(() => { tssl_statusText.Text = "ADB Server启动成功"; }));
                }
                else
                {
                    MessageBox.Show("ADB Server启动失败", "错误");
                    //Invoke(new Action(() => { tssl_statusText.Text = "ADB Server启动失败"; }));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }));

            }
        }

        private bool CheckAdbConnect()
        {
            string ret, connectInfo = "";

            //tssl_statusText.Text = "连接状况检查中...";

            mAdbManager.AdbDevicesList(out ret);

            Console.WriteLine(ret);

            string[] lines = ret.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("List of devices attached") == true)
                {
                    if (lines.Length > (i + 1))
                    {
                        connectInfo = lines[i + 1];
                        break;
                    }
                }
            }

            if (connectInfo.Length <= 5)
            {
                lab_linkState.Text = "未连接";
                lab_linkState.ForeColor = Color.Red;

                lab_version.Text = "";

                //tssl_statusText.Text = "连接状况检查完毕";

                return false;
            }
            else if (connectInfo.Contains("offline"))
            {
                lab_linkState.Text = "连接异常";
                lab_linkState.ForeColor = Color.Red;

                lab_version.Text = "";

                //tssl_statusText.Text = "连接状况检查完毕";

                return false;
            }
            else
            {
                Common.status = Common.AdbState.CONNECTED;

                lab_linkState.Text = "已连接 " + connectInfo;
                lab_linkState.ForeColor = Color.Green;

                string ver = GetVersion();
                if (ver != null)
                {
                    lab_version.Text = ver;
                }
                
                //tssl_statusText.Text = "连接状况检查完毕";

                return true;
            }
        }

        private string GetVersion()
        {
            string result;

            mAdbManager.AdbGetVersion(out result);

            string[] lines = result.Split(new string[] { "\r\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("ro.build.display.id=") == true)
                {
                    return lines[i].Split('=')[1];
                }
            }

            return "";
        }

        private bool CheckNetword(string ip)
        {
            //tssl_statusText.Text = "网络状况检查检查中...";

            if (ip.Length < 7)
            {
                lab_netState.Text = "请设置终端IP地址";
                lab_netState.ForeColor = Color.Red;

                //tssl_statusText.Text = "网络状况检查完毕";
                return false;
            }

            bool ret = Utils.PingIpOrDomainName(ip);
            if (ret == true)
            {
                lab_netState.Text = "网络通(" + ip + ")";
                lab_netState.ForeColor = Color.Green;

                //tssl_statusText.Text = "网络状况检查检查完毕";
                return true;
            }
            else
            {
                lab_netState.Text = "网络不通(" + ip + ")";
                lab_netState.ForeColor = Color.Red;

                //tssl_statusText.Text = "网络状况检查检查完毕";
                return false;
            }
        }

        private void rbtn_net_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_net.Checked == true)
            {
                lab_netState.Text = "";
                lab_linkState.Text = "";
                lab_version.Text = "";

                tb_ipaddr.Enabled = true;

                MessageBox.Show("请确认断开与终端的USB连接");
            }
        }

        private void rbtn_usb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_usb.Checked == true)
            {
                string result;
                mAdbManager.AdbDisconnect(out result);

                btn_flush_Click(null, null);

                tb_ipaddr.Enabled = false;
            }
        }

        private void btn_flush_Click(object sender, EventArgs e)
        {
            //CheckNetword(tb_ipaddr.Text);

            if (rbtn_net.Checked == true)
            {
                bool ret = CheckNetword(tb_ipaddr.Text);

                if (ret == false)
                {
                    lab_linkState.Text = "";
                    lab_version.Text = "";
                    MessageBox.Show("网络不通", "警告");
                    return;
                }

                CheckAdbConnect();
                
            }
            else
            {
                lab_netState.Text = "USB连接";
                lab_netState.ForeColor = Color.Green;
                CheckAdbConnect();
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (rbtn_net.Checked == true)
            {
                string ipaddr = tb_ipaddr.Text;

                if (Utils.CheckIP(ipaddr) == false)
                {
                    MessageBox.Show("IP地址输入错误（例：192.168.1.1）");
                    return;
                }

                bool ret = CheckNetword(ipaddr);

                if (ret == false)
                {
                    lab_linkState.Text = "";
                    lab_version.Text = "";
                    MessageBox.Show("网络不通", "警告");
                    return;
                }

                string result;
                mAdbManager.AdbConnect(ipaddr, out result);

            }
            else if (rbtn_usb.Checked == true)
            {
                lab_netState.Text = "USB连接";
                lab_netState.ForeColor = Color.Green;

            }

            bool res = CheckAdbConnect();

            if (res == true)
            {
                lab_version.Text = GetVersion();
            }

            UIUpdate(true);

        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            if (rbtn_net.Checked == true)
            {
                string result;
                mAdbManager.AdbDisconnect(out result);
                UIUpdate(true);

                CheckAdbConnect();
            }
        }

        private void btn_screencap_Click(object sender, EventArgs e)
        {
            ScreenCapThread = new Thread(new ThreadStart(ScreenCap));
            ScreenCapThread.Start();

            if (mInfoForm != null)
            {
                mInfoForm.Close();
                mInfoForm = null;
            }

            mInfoForm = new InfoForm("正在截屏，请稍候...");
            mInfoForm.ShowDialog();
        }

        private void ScreenCap()
        {
            //Invoke(new Action(() => { tssl_statusText.Text = "开始截屏..."; }));

            string result;
            mAdbManager.AdbScreenCap("/sdcard/dst_snapshot.png", out result);

            DateTime now = DateTime.Now;
            string time = now.ToString("yyyy-MM-dd HH:mm:ss");
            string pc_path = "snapshot/snapshot-" + now.ToString("yyyyMMddHHmmss") + ".png";
            mAdbManager.AdbPullFile("/sdcard/dst_snapshot.png", pc_path, out result);

            pb_screencap.ImageLocation = pc_path;

            Invoke(new Action(() =>
            {
                lab_screenTime.Text = time;
                //tssl_statusText.Text = "截屏完成";
            }));

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }));

            }
        }

        private void btn_screenon_Click(object sender, EventArgs e)
        {
            string result;
            mAdbManager.AdbScreenCtrl(true, out result);
        }
        private void btn_screenoff_Click(object sender, EventArgs e)
        {
            string result;
            mAdbManager.AdbScreenCtrl(false, out result);
        }

        private void btn_reboot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否重启？", "",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RebootThread = new Thread(new ThreadStart(BoxReboot));
                RebootThread.Start();

                mInfoForm = new InfoForm("正在重启，请稍候...");
                mInfoForm.ShowDialog();
            }

        }

        //Thread
        private void BoxReboot()
        {

            string result;
            mAdbManager.AdbReboot(out result);

            mAdbManager.AdbDisconnect(out result);

            Common.status = Common.AdbState.STARTED;

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;

                    btn_flush_Click(null, null);
                }));

            }
            
        }

        private void btn_getLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            string path;

            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                if (dilog.SelectedPath.EndsWith("\\") == true)
                {
                    path = dilog.SelectedPath + "log-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    path = dilog.SelectedPath + "\\log-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                //mAdbManager.AdbPullFile("/sdcard/digitalsignage/log", path, out result);
                //if (MessageBox.Show("日志获取成功，是否打开日志文件夹？", "成功",
                //    MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                //{
                //    System.Diagnostics.Process.Start("explorer.exe", dilog.SelectedPath);
                //}

                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(GetLog);
                GetLogThread = new Thread(ParStart);
                GetLogThread.Start(path);

                if (mInfoForm != null)
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }
                mInfoForm = new InfoForm("正在获取日志，请稍候...");
                mInfoForm.ShowDialog();
            }
        }

        //Thread
        private void GetLog(object path)
        {

            string result;

            mAdbManager.AdbPullFile("/sdcard/digitalsignage/log", (string)path, out result);

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }));

                if (MessageBox.Show("日志获取成功，是否打开日志文件夹？", "成功",
                    MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", (string)path);
                }
            }

        }

        private void btn_ip_Click(object sender, EventArgs e)
        {
            IPForm ipform = new IPForm();

            if (ipform.ShowDialog() == DialogResult.OK)
            {
                string result;

                Utils.RunCmd("adb shell cp /data/data/com.android.providers.settings/databases/settings.db /data/data/com.android.providers.settings/databases/settings.db.bak");

                mAdbManager.AdbRemoveFile("/data/data/com.android.providers.settings/databases/settings.db", out result);
                mAdbManager.AdbRemoveFile("/data/data/com.android.providers.settings/databases/settings.db-shm", out result);
                mAdbManager.AdbRemoveFile("/data/data/com.android.providers.settings/databases/settings.db-wal", out result);

                mAdbManager.AdbPushFile("settings.db", "/data/data/com.android.providers.settings/databases/settings.db", out result);

                btn_reboot_Click(null, null);
            }
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "APK文件|*.apk|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;

                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(Install);
                InstallThread = new Thread(ParStart);
                InstallThread.Start(path);

                if (mInfoForm != null)
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }
                mInfoForm = new InfoForm("正在安装，请稍候...");
                mInfoForm.ShowDialog();
            }
        }

        //Thread
        private void Install(object path)
        {

            string result;
            mAdbManager.AdbInstallAPP((string)path, out result);

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }));

            }

            Console.WriteLine(result);

            if (result.Contains("Failure") == true)
            {
                string[] list = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].Contains("Failure") == true)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("list[i]");
                        }));
                        break;
                    }
                }
            }
        }

        private void btn_uninstall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否卸载公告软件？", "",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UninstallThread = new Thread(new ThreadStart(Uninstall));
                UninstallThread.Start();

                mInfoForm = new InfoForm("正在卸载，请稍候...");
                mInfoForm.ShowDialog();
            }
        }

        //Thread
        private void Uninstall()
        {

            string result;
            mAdbManager.AdbUninstallAPP("com.wuchen.android.digital_signage", out result);

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    mInfoForm.Close();
                    mInfoForm = null;
                }));

            }

            if (result.Contains("Failure") == true)
            {

                Invoke(new Action(() =>
                {
                    MessageBox.Show("卸载失败");
                }));
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            string result;
            mAdbManager.AdbStartApp("com.wuchen.android.digital_signage/.SplashActivity", out result);

            if (result.Contains("Error") == true)
            {
                MessageBox.Show("公告启动失败");
            }
            else
            {
                MessageBox.Show("公告启动完成");
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            string result;
            mAdbManager.AdbStopApp("com.wuchen.android.digital_signage", out result);

            if (result.Contains("Error") == true)
            {
                MessageBox.Show("公告关闭失败");
            }
            else
            {
                MessageBox.Show("公告关闭完成");
            }
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        private void btn_app_version_Click(object sender, EventArgs e)
        {
            string result;

            tb_info.Text = "";

            mAdbManager.AdbGetAPPInfo("com.wuchen.android.digital_signage", out result);

            string[] list = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Contains("versionCode") == true || list[i].Contains("versionName") == true)
                {
                    tb_info.Text += list[i].Trim() + "\r\n";
                }
            }

                
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (btn_search.Text.Equals("开始扫描"))
            {
                btn_search.Text = "结束扫描";

                if (Utils.CheckIPSegment(tb_start_ip.Text) == false)
                {
                    MessageBox.Show("网段地址输入错误（例：192.168.1）");
                    return;
                }

                ParameterizedThreadStart ParStart = new ParameterizedThreadStart(SearchNetwork);
                SearchNetworkThread = new Thread(ParStart);
                SearchNetworkThread.Start(tb_start_ip.Text);
            }
            else
            {
                btn_search.Text = "开始扫描";

                if (SearchNetworkThread != null)
                {
                    SearchNetworkThread.Abort();
                    SearchNetworkThread = null;
                }
            }


        }

        private void SearchNetwork(object ip_start)
        {
            string ipSeg = (string)ip_start;

            Invoke(new Action(() =>
            {
                lv_search_result.Items.Clear();
            }));

            for (int i = 1; i < 255; i++)
            {
                string ip = ipSeg + "." + i;
                bool ret = Utils.PingIpOrDomainName(ip);
                if (ret == true)
                {
                    Invoke(new Action(() =>
                    {
                        lv_search_result.Items.Add(new ListViewItem(ip));
                    }));
                }
            }

            Invoke(new Action(() =>
            {
                btn_search.Text = "开始扫描";
            }));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ServerStartThread != null/* && ServerStartThread.IsAlive == true*/)
            {
                ServerStartThread.Abort();
                ServerStartThread = null;
            }

            if (RebootThread != null/* && RebootThread.IsAlive == true*/)
            {
                RebootThread.Abort();
                RebootThread = null;
            }

            if (ScreenCapThread != null/* && ScreenCapThread.IsAlive == true*/)
            {
                ScreenCapThread.Abort();
                ScreenCapThread = null;
            }

            if (InstallThread != null/* && InstallThread.IsAlive == true*/)
            {
                InstallThread.Abort();
                InstallThread = null;
            }

            if (UninstallThread != null/* && UninstallThread.IsAlive == true*/)
            {
                UninstallThread.Abort();
                UninstallThread = null;
            }

            if (SearchNetworkThread != null/* && SearchNetworkThread.IsAlive == true*/)
            {
                SearchNetworkThread.Abort();
                SearchNetworkThread = null;
            }

            if (GetLogThread != null/* && GetLogThread.IsAlive == true*/)
            {
                GetLogThread.Abort();
                GetLogThread = null;
            }
            

            mConfig.AppSettings.Settings["ipaddr"].Value = tb_ipaddr.Text;
            mConfig.AppSettings.Settings["search_start_ip"].Value = tb_start_ip.Text;
            mConfig.AppSettings.Settings["usb_check"].Value = rbtn_usb.Checked == true ? "true" : "false";
            mConfig.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void lv_search_result_MouseClick(object sender, MouseEventArgs e)
        {
            tb_ipaddr.Text = lv_search_result.SelectedItems[0].SubItems[0].Text;
        }

        private void btn_trim_Click(object sender, EventArgs e)
        {
            string result;

            string path = "display.area_radio";
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write("100");
            sw.Close();

            mAdbManager.AdbPushFile(path, "/mnt/private/display.area_radio", out result);

            btn_reboot_Click(null, null);
        }

    }
}


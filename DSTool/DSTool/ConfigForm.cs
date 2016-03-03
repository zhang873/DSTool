using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DSTool
{
    public partial class ConfigForm : Form
    {
        private AdbManager mAdbManager;

        private string configPath;

        private string template;

        public ConfigForm()
        {
            InitializeComponent();

            configPath = "config.dsconf";

            mAdbManager = new AdbManager();

            template = "name=box01\r\nservice=http://192.168.1.14:8500\r\ninterval=30\r\nmanual_screen=on\r\nauto_snapshot=0\r\nauto_screen.num=1\r\nauto_screen.0=00:00:00,23:59:59,01111111\r\nauto_reboot.num=1\r\nauto_reboot.0=01:00:00,01111111\r\ndebug=0";

            string result;

            File.Delete(configPath);
            mAdbManager.AdbPullFile("/sdcard/digitalsignage/config.dsconf", configPath, out result);

            if (File.Exists(configPath) == true)
            {
                StreamReader sr = new StreamReader(configPath, Encoding.UTF8);
                string config = sr.ReadToEnd();
                sr.Close();
                tb_config.Text = config;
            }

        }

        private void btn_use_template_Click(object sender, EventArgs e)
        {
            tb_config.Text = template;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(configPath, false);
            sw.Write(tb_config.Text);
            sw.Close();

            string result;

            mAdbManager.AdbStopApp("com.wuchen.android.digital_signage", out result);
            mAdbManager.AdbPushFile(configPath, "/sdcard/digitalsignage/config.dsconf", out result);
            mAdbManager.AdbStartApp("com.wuchen.android.digital_signage/.SplashActivity", out result);

            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}

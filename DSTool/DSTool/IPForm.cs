using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;

namespace DSTool
{
    public partial class IPForm : Form
    {
        private AdbManager mAdbManager;

        private string mSplitePath;
        private string[] ipaddr;
        private string[] newIpaddr;

        private Form mInfoForm = null;
        private Thread BoxSetIpaddrThread;

        public IPForm()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            mSplitePath = "settings.db";

            mAdbManager = new AdbManager();

            GetIpaddr();
        }

        private string[] GetIpaddr()
        {
            string result;

            mAdbManager.AdbGetIPaddr(out result);

            ipaddr = new string[3];

            string[] list = result.Split(new string[] { "\r\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Contains("inet addr") == true)
                {
                    string[] list2 = list[i].Split(' ');
                    for (int j = 0; j < list2.Length; j++)
                    {
                        if (list2[j].Contains("addr:") == true)
                        {
                            ipaddr[0] = list2[j].Split(':')[1];
                        }
                        else if (list2[j].Contains("Mask:") == true)
                        {
                            ipaddr[1] = list2[j].Split(':')[1];
                        }
                    }
                    break;
                }
            }

            tb_ipaddr.Text = ipaddr[0];
            tb_mask.Text = ipaddr[1];

            mAdbManager.AdbGetRoute(out result);

            list = result.Split(new string[] { "\r\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Contains("default") == true)
                {
                    string[] list2 = list[i].Split(' ');
                    for (int j = 0; j < list2.Length; j++)
                    {
                        if (list2[j].Length >= 7 && list2[j].Equals("default") == false)
                        {
                            ipaddr[2] = list2[j];
                            break;
                        }
                    }
                }
            }
            tb_gateway.Text = ipaddr[2];

            mAdbManager.AdbPullFile("/data/data/com.android.providers.settings/databases/settings.db", mSplitePath, out result);

            return ipaddr;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (Utils.CheckIP(tb_ipaddr.Text) == false)
            {
                MessageBox.Show("IP输入错误");
                return;
            }

            if (Utils.CheckMask(tb_mask.Text) == false)
            {
                MessageBox.Show("子网掩码输入错误");
                return;
            }

            if (Utils.CheckIP(tb_gateway.Text) == false)
            {
                MessageBox.Show("网关输入错误");
                return;
            }

            if (MessageBox.Show("是否设置此IP？", "",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BoxSetIpaddrThread = new Thread(new ThreadStart(BoxSetIpaddr));
                BoxSetIpaddrThread.Start();

                mInfoForm = new InfoForm("正在设置IP，请稍候...");
                mInfoForm.ShowDialog();
            }
        }

        //Thread
        private void BoxSetIpaddr()
        {

            newIpaddr = new string[3];

            newIpaddr[0] = tb_ipaddr.Text;
            newIpaddr[1] = tb_mask.Text;
            newIpaddr[2] = tb_gateway.Text;

            bool needReboot = false;

            string dbpath = @"Data Source=" + mSplitePath;

            string sqls = "";

            if (newIpaddr[0].Equals(ipaddr[0]) == false)
            {
                sqls += "update secure set value='" + newIpaddr[0] + "' where name='eth_ip';";
                needReboot = true;
            }

            if (newIpaddr[1].Equals(ipaddr[1]) == false)
            {
                sqls += "update secure set value='" + newIpaddr[1] + "' where name='eth_netmask';";
                needReboot = true;
            }

            if (newIpaddr[2].Equals(ipaddr[2]) == false)
            {
                sqls += "update secure set value='" + newIpaddr[2] + "' where name='eth_route';";
                needReboot = true;
            }


            if (needReboot == true)
            {
                sqls += "update secure set value='0' where name='eth_mode';";
                sqls += "update secure set value='1' where name='eth_on';";
                UpdateSqlite(dbpath, sqls);

                DialogResult = DialogResult.OK;
            }

            if (mInfoForm != null)
            {
                Invoke(new Action(() =>
                {
                    if (mInfoForm != null)
                    {
                        mInfoForm.Close();
                        mInfoForm = null;
                    }

                    this.Close();
                }));

            }
        }

        private void UpdateSqlite(string dataSource, string sqls)
        {

            SQLiteConnection conn = null;

            conn = new SQLiteConnection(dataSource);//创建数据库实例，指定文件位置
            conn.Open();//打开数据库，若文件不存在会自动创建

            SQLiteCommand sqlite_cmd = new SQLiteCommand(conn);

            //for (int i = 0; i < sqls.Length; i++)
            //{
            //    string sql = sqls[i];

                sqlite_cmd.CommandText = sqls;
                sqlite_cmd.ExecuteNonQuery();
            //}

                sqlite_cmd.Dispose();

            conn.Close();

            conn = null;
        
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IPForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BoxSetIpaddrThread != null)
            {
                BoxSetIpaddrThread.Abort();
                BoxSetIpaddrThread = null;
            }
        }
    }
}

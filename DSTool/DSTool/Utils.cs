using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace DSTool
{
    public class Utils
    {
        /// <summary>
        /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败 
        /// </summary>
        /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
        /// <returns></returns>
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string RunCmd(string str)
        {
            Console.WriteLine("start " + str + " " + DateTime.Now.ToLongTimeString());

            bool isNotTimeout = true;
            string output = "";

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");

            if (str.Contains("connect") == true)
            {
                isNotTimeout = p.WaitForExit(5000);
            }
            else
            {
                isNotTimeout = p.WaitForExit(20000);
            }

            if (!isNotTimeout)
            {
                p.Kill();
                p.WaitForExit();
            }
            else
            {
                output = p.StandardOutput.ReadToEnd();
                p.Close();
            }

            Console.WriteLine(output);

            return output;
        }

        public static bool CheckIP(string ip)
        {
            try
            {
                string[] list = ip.Split('.');

                if (list.Length != 4)
                {
                    return false;
                }

                for (int i = 0; i < list.Length; i++)
                {
                    int item = Int32.Parse(list[i]);

                    if (item >= 255 || item <= 0)
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public static bool CheckMask(string mask)
        {
            try
            {
                string[] list = mask.Split('.');

                if (list.Length != 4)
                {
                    return false;
                }

                for (int i = 0; i < list.Length; i++)
                {
                    int item = Int32.Parse(list[i]);

                    if (item > 255 || item < 0)
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public static bool CheckIPSegment(string ip)
        {
            try
            {
                string[] list = ip.Split('.');

                if (list.Length != 3)
                {
                    return false;
                }

                for (int i = 0; i < list.Length; i++)
                {
                    int item = Int32.Parse(list[i]);

                    if (item > 255 || item < 0)
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSTool
{
    public class AdbManager
    {
        public AdbManager()
        {
        }


        #region 重启ADB服务
        public bool AdbServerReStart()
        {
            Utils.RunCmd("adb kill-server");
            string result = Utils.RunCmd("adb start-server");

            if (result.Contains("daemon started successfully") == true)
            {
                Common.status = Common.AdbState.STARTED;
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 查看连接设备
        public bool AdbDevicesList(out string result)
        {
            result = Utils.RunCmd("adb devices");

            return true;

        }
        #endregion

        #region 连接android设备
        public bool AdbConnect(string ip, out string result)
        {
            AdbDisconnect(out result);

            result = Utils.RunCmd("adb connect " + ip);
            if (result.Contains("connected to") == true)
            {
                Common.status = Common.AdbState.CONNECTED;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 断开android设备
        public bool AdbDisconnect(out string result)
        {
            result = Utils.RunCmd("adb disconnect");
            Common.status = Common.AdbState.STARTED;
            return true;
        }
        #endregion

        #region 安装程序
        public bool AdbInstallAPP(string path, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb install -r \"" + path + "\"");

            return true;
        }
        #endregion

        #region 卸载程序
        public bool AdbUninstallAPP(string package, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb uninstall " + package);

            return true;
        }
        #endregion

        #region 截屏
        public bool AdbScreenCap(string box_path, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell screencap -p \"" + box_path + "\"");

            return true;
        }
        #endregion

        #region 开关屏
        public bool AdbScreenCtrl(bool on, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell echo " + (on == true ? "on" : "mem") + " > /sys/power/state");

            return true;
        }
        #endregion

        #region 重启
        public bool AdbReboot(out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell reboot");
            //result = Utils.RunCmd("adb shell am broadcast -a com.wuchen.android.BroadcastReceiver.dsmonitor --ei Function 1");

            return true;
        }
        #endregion

        #region 从android设备中取文件
        public bool AdbPullFile(string box_path, string pc_path, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb pull " + box_path + " \"" + pc_path + "\"");

            return true;
        }
        #endregion

        #region 向android设备中推文件
        public bool AdbPushFile(string pc_path, string box_path, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb push " + pc_path + " " + box_path);

            return true;
        }
        #endregion

        #region 启动某个程序
        public bool AdbStartApp(string main_class, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell am start -n " + main_class);

            return true;
        }
        #endregion

        #region 关闭某个程序
        public bool AdbStopApp(string package, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell am force-stop " + package);

            return true;
        }
        #endregion

        #region 获取软件信息
        public bool AdbGetAPPInfo(string package, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell dumpsys package " + package);

            return true;
        }
        #endregion

        #region 获取固件信息
        public bool AdbGetVersion(out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell cat /system/build.prop");

            return true;
        }
        #endregion

        public bool AdbGetIPaddr(out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell busybox ifconfig");

            return true;
        }

        public bool AdbGetRoute(out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell busybox route");

            return true;
        }

        public bool AdbRemoveFile(string path, out string result)
        {
            if (Common.status != Common.AdbState.CONNECTED)
            {
                result = "";
                return false;
            }

            result = Utils.RunCmd("adb shell rm " + path);

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSTool
{
    public class Common
    {
        public enum AdbState
        {
            NONE,
            STARTED,
            CONNECTED
        }

        public static AdbState status;
    }
}

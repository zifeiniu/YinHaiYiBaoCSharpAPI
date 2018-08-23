using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
   public static class DateHelper
    {
        //放在公共区域
        [DllImport("Kernel32.dll")]
        private static extern bool SetSystemTime(ref SystemTime sysTime);

        [DllImport("Kernel32.dll")]
        private static extern void GetSystemTime(ref SystemTime sysTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }

        /// <summary> 
        /// 设置系统时间 
        /// </summary> 
        public static Boolean SyncTime(DateTime currentTime)
        {
            Boolean flag = false;
            try
            {
                SystemTime sysTime = new SystemTime();
                sysTime.wYear = Convert.ToUInt16(currentTime.Year);
                sysTime.wMonth = Convert.ToUInt16(currentTime.Month);
                sysTime.wDay = Convert.ToUInt16(currentTime.Day);
                sysTime.wDayOfWeek = Convert.ToUInt16(currentTime.DayOfWeek);
                sysTime.wMinute = Convert.ToUInt16(currentTime.Minute);
                sysTime.wSecond = Convert.ToUInt16(currentTime.Second);
                sysTime.wMiliseconds = Convert.ToUInt16(currentTime.Millisecond);

                //处理北京时间 
                int nBeijingHour = currentTime.Hour - 8;
                if (nBeijingHour <= 0)
                {
                    nBeijingHour = 24;
                    sysTime.wDay = Convert.ToUInt16(currentTime.Day - 1);
                    //sysTime.wDayOfWeek = Convert.ToUInt16(current.DayOfWeek - 1); 
                }
                else
                {
                    sysTime.wDay = Convert.ToUInt16(currentTime.Day);
                    sysTime.wDayOfWeek = Convert.ToUInt16(currentTime.DayOfWeek);
                }
                sysTime.wHour = Convert.ToUInt16(nBeijingHour);

                SetSystemTime(ref sysTime);//设置本机时间
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }
    }
}

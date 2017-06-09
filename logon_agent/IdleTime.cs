using System;
using System.Runtime.InteropServices;
namespace logon_agent
{
    public static class IdleTime
    {
        public static TimeSpan AsTimeSpan
        {
            get { return TimeSpan.FromMilliseconds(InMilliseconds); }
        }

        public static uint InMilliseconds
        {
            get
            {
                var lii = new LASTINPUTINFO { cbSize = SizeOfLASTINPUTINFO };
                if (!GetLastInputInfo(ref lii))
                    return 0;
                return unchecked((uint)Environment.TickCount - lii.dwTime);
            }
        }

        #region p/Invoke

        [DllImport("User32.dll")]
        extern static bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        static readonly uint SizeOfLASTINPUTINFO = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO));

        #endregion
    }
}
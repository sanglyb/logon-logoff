using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public class get_username_from_id
{
    [DllImport("Wtsapi32.dll")]
    private static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WtsInfoClass wtsInfoClass, out System.IntPtr ppBuffer, out int pBytesReturned);
    [DllImport("Wtsapi32.dll")]
    private static extern void WTSFreeMemory(IntPtr pointer);

    public enum WtsInfoClass
    {
        WTSInitialProgram,
        WTSApplicationName,
        WTSWorkingDirectory,
        WTSOEMId,
        WTSSessionId,
        WTSUserName,
        WTSWinStationName,
        WTSDomainName,
        WTSConnectState,
        WTSClientBuildNumber,
        WTSClientName,
        WTSClientDirectory,
        WTSClientProductId,
        WTSClientHardwareId,
        WTSClientAddress,
        WTSClientDisplay,
        WTSClientProtocolType,
        WTSIdleTime,
        WTSLogonTime,
        WTSIncomingBytes,
        WTSOutgoingBytes,
        WTSIncomingFrames,
        WTSOutgoingFrames,
        WTSClientInfo,
        WTSSessionInfo,
    }

    public static string GetUsernameBySessionId(int sessionId, bool prependDomain)
    {
        IntPtr buffer;
        int strLen;
        string username = "SYSTEM";
        if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WTSUserName, out buffer, out strLen) && strLen > 1)
        {
            username = Marshal.PtrToStringAnsi(buffer);
            WTSFreeMemory(buffer);
            if (prependDomain)
            {
                if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WTSDomainName, out buffer, out strLen) && strLen > 1)
                {
                    username = Marshal.PtrToStringAnsi(buffer) + "\\" + username;
                    WTSFreeMemory(buffer);
                }
            }
        }
        return username;
    }

    public static string GetSessionTypeBySessionId(int sessionId)
    {
        IntPtr buffer;
        int strLen;
        string is_rdp = "";
        var retval = WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WTSClientProtocolType, out buffer, out strLen);
        if (retval)
            is_rdp = Marshal.PtrToStringAnsi(buffer);
        WTSFreeMemory(buffer);
        /*if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WTSClientProtocolType, out buffer, out strLen))
        {
            username = Marshal.PtrToStringAnsi(buffer);
            WTSFreeMemory(buffer);
            }
        }*/
        
        return is_rdp;
    }
}
    /*
    public static T GetSessionTypeByID<T>(int sessionId)
    {
        IntPtr buffer;
        int strLen;
        T type;
        if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WtsInfoClass.WTSClientProtocolType, out buffer, out strLen))
        {
            if (typeof(T).IsEnum)
            {
                Type underlyingType = Enum.GetUnderlyingType(typeof(T));
                type = (T)Marshal.PtrToStructure(buffer, underlyingType);
            }
            else
                type = (T)Marshal.PtrToStructure(buffer, typeof(T));
        }
        return default(T);*/
/*}
    private static T QuerySessionInfo<T>(System.IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass)
    {

        if (WTSQuerySessionInformation(hServer, sessionId, wtsInfoClass, out ppBuffer, out pBytesReturned))
        {
            try
            {
                T result;
                if (typeof(T).IsEnum)
                {
                    Type underlyingType = Enum.GetUnderlyingType(typeof(T));
                    result = (T)Marshal.PtrToStructure(ppBuffer, underlyingType);
                }
                else
                    result = (T)Marshal.PtrToStructure(ppBuffer, typeof(T));

                return result;
            }
            finally
            {
                WTSFreeMemory(ppBuffer);
                ppBuffer = IntPtr.Zero;

            }
        }
        return default(T);
    }*/



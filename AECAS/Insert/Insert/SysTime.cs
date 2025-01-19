// Copyright
// Microsoft Corporation
// All rights reserved

// SysTime.cs

using System;
using System.Runtime.InteropServices;

namespace serialPortCreate
{    

    [StructLayout(LayoutKind.Sequential)]
    public class SystemTime
    {
        public ushort year;
        public ushort month;
        public ushort dayOfWeek;
        public ushort day;
        public ushort hour;
        public ushort minute;
        public ushort second;
        public ushort milliseconds;
    }

    public class LibWrap
    {
        // VOID GetSystemTime(LPSYSTEMTIME lpSystemTime)
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime([In, Out] SystemTime st);
    }    
}
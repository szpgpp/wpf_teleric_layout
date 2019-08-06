using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_LoadXml
{
    public static class XGC
    {
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        public static void ClearMemory()
        {
            PrintMemory("Start ");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            PrintMemory("End ");
        }
        public static void PrintMemory(string msg)
        {
            Process proc = Process.GetCurrentProcess();
            long usedMemory = proc.PrivateMemorySize64;
            Debug.WriteLine(msg + (usedMemory / 1024 / 1024) + "M");
        }
    }
}

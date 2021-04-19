using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net;

namespace EvasionPractice
{
    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        [StructLayout(LayoutKind.Sequential, Size = 40)]
        private struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;             
            public uint PageFaultCount;        
            public uint PeakWorkingSetSize;  
            public uint WorkingSetSize;        
            public uint QuotaPeakPagedPoolUsage;    
            public uint QuotaPagedPoolUsage;
            public uint QuotaPeakNonPagedPoolUsage;
            public uint QuotaNonPagedPoolUsage;
            public uint PagefileUsage;
            public uint PeakPagefileUsage;
        }
        [DllImport("psapi.dll", SetLastError = true)]
        static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint size);
        static void Main(string[] args)
        {
            PROCESS_MEMORY_COUNTERS pmc;
            pmc.cb = (uint)Marshal.SizeOf(typeof(PROCESS_MEMORY_COUNTERS));
            GetProcessMemoryInfo(GetCurrentProcess(), out pmc, pmc.cb);
            if (pmc.WorkingSetSize <= 3500000)
            {
                runner();
            }
            return;
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
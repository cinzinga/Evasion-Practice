using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EvasionPractice
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
                uint processAccess,
                bool bInheritHandle,
                int processId
            );
        static void Main(string[] args)
        {
            IntPtr proc = OpenProcess(0x001F0FFF, false, 4);
            if (proc == IntPtr.Zero)
            {
                runner();
            }
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}

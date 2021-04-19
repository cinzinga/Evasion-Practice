using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace EvasionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = "C:\\Users\\User\\Desktop\\tmp.file";
            string buff = "1234";
            File.WriteAllText(file_path, buff);
            string readText = File.ReadAllText(file_path);
            if (readText == buff)
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
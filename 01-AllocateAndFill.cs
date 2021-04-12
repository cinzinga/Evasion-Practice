using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvasionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[32768 * 32768]; 
            Array.Clear(data, 0, data.Length); 
            Console.WriteLine("~1GB filled!");
            System.Threading.Thread.Sleep(1000);

            runner();
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}

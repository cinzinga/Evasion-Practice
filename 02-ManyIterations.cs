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
            int count = 0;
            int max = 900000000;
            for (int i = 0; i < max; i++)
            {
                count++;
            }
            if (count == max)
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

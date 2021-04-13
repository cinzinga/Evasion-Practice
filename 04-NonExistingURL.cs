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
        static void Main(string[] args)
        {
            WebRequest req = WebRequest.Create("http://www.notdetectedmaliciouscode.com/");
            WebResponse res;
            try
            {
                res = req.GetResponse();
            }
            catch
            {
                Environment.Exit(0);
            }
            runner();
        }
        static void runner()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
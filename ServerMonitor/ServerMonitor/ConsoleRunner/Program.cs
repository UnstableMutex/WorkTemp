using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorCL;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Monitor.Out = Console.Out;
            Monitor.Run();
            Console.ReadKey();
        }
    }
}

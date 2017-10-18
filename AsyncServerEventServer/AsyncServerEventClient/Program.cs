using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLib;

namespace AsyncServerEventClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EventClient c = new EventClient();
          var res=  c.ReadEvents();
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}

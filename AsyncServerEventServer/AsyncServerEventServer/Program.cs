using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SharedLib;

namespace AsyncServerEventServer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventServer s = new EventServer();
            s.Start();
            Console.ReadKey();
        }
    }

  
}

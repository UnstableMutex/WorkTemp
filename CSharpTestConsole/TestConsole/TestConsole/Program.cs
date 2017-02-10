using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
        	int? d=6;
        	Console.WriteLine(d.ToString());
            int? n = null;
            var ns = n.ToString();
            Console.WriteLine(ns);
            Console.ReadKey();
        }
    }
}

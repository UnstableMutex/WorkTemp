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
            var i = 400;
            var test1 = (test) i;
        }
    }
    [Flags]
    enum test:int
    {
        one =1, two =2 , four=4,e=8,s=16,b=32,c=64,d=128,e1=256
    }
}

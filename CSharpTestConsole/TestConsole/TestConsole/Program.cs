using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        private const  int StepCount = 500;
        private const decimal startPrice = 5;

        private const decimal endPrice = 1.5M;

        private static decimal stepprice;
        static void Main(string[] args)
        {
            decimal sum;
            for (int i = 1; i < StepCount; i++)
            {
                var res = realY(i);
               Console.WriteLine(res);
            }
            Console.ReadKey();

        }

    

      static  decimal stepPrice(decimal step)
        {
            var realX = -.007M * step+5.007M;
            return realX;
        }

     static   decimal realY(int step)
        {
            var tmp = 860*step/500 ;
            return stepPrice(tmp);
        }

             
      
    }
}

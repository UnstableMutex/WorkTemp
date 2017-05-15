using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Calcer();
            var stepsize = c.CalcStepSize();
            var result = 0M;
            var steps = 500;
            for (int i = 0; i < steps; i++)
            {
                result += (Calcer.StartPrice - (stepsize * i));

            }
            Console.WriteLine("result={0}",result);
            Console.ReadKey();
        }
    }
    class Calcer
    {

        public decimal CalcStepSize()
        {
            for (decimal i = 1.8770M; i < 2.1M; i = i + .0000001M)
            {
                x = i;
                var res = StepPrice();
                Console.WriteLine(res);

                if (res < TotalCost)
                {
                    Console.WriteLine("x={0}", i);
                    Console.WriteLine("step={0}", StepSize());
                    return StepSize();

                }
            }
            throw new Exception();
        }

        public const int StepCount = 500;
        public const decimal StartPrice = 5;
        public const decimal EndPrice = 1.5M;
        private const decimal TotalCost = 860;
        const decimal Coridor = StartPrice - EndPrice;
        private decimal startx = 0.01M;
        private decimal x;
        decimal StepPrice()
        {
            decimal res = 0;
            for (int i = 0; i < 500; i++)
            {
                res += OneIter(i);
            }
            return res;
        }
        decimal OneIter(int step)
        {
            return StartPrice - step * StepSize();
        }

        decimal StepSize()
        {
            return ((Coridor * x) / StepCount);
        }
    }
}

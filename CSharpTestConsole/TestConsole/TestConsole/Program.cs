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
            int[] arr = {14, 45, 67};
            var s = Join(arr);
            var a = string.Join(",", arr.Select(x=>x.ToString()).ToArray());
            var c = arr.ToString();
            Console.WriteLine(s);
            Console.ReadKey();
        }
               

             
        public static string Join(int[] array)
        {
            string sTrades = string.Empty;
            for (int i = 0; i < array.Count(); i++)
            {
                sTrades += array[i].ToString();
                if (i < array.Count() - 1)
                    sTrades += ",";
            }
            return sTrades;
        }
    }
}

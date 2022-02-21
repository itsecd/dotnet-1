using System;
using PPLab1.Model;

namespace PPLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Function f = new LogFunct()
            {
                Elems = new Data(10, 5)
            };
            Function f1 = new LogFunct()
            {
                Elems = new Data(10, 3)
            };

            //Console.WriteLine(f.calc_funct(2));
            //Console.WriteLine(f.Equals(f1));
            Console.WriteLine(f.GetHashCode());
            Console.WriteLine(f1.GetHashCode());

        }
    }
}

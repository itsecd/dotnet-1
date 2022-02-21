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

            Console.WriteLine(f.calc_funct(2));
            Console.WriteLine(f);

        }
    }
}

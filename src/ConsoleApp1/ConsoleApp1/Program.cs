using PPLab1.Model;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Data(100, 100);
            var d = new Data(1, 4);
            var b = new ExpFunct(a);
            var c = new ExpFunct(a);
            var qwe = b.Elems;
            qwe.A = 0;
            qwe.Coeff = 50;

            Console.WriteLine(qwe);

            Console.WriteLine(b);
            Console.WriteLine(b.Elems.Coeff);
            Console.WriteLine(b.GetHashCode() == c.GetHashCode());
            a.A = 0;
            Console.WriteLine(b.GetHashCode() == c.GetHashCode());
        }
    }
}

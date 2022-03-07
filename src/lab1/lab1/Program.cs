using System;
using lab1.Model;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            BufferedMatrix a = new BufferedMatrix(5, 5);
            Console.WriteLine(a.GetValue(0, 0));
            Console.WriteLine(a.Height);
            Console.WriteLine(a.Width);
            Console.WriteLine(a.ToString());
        }
    }
}

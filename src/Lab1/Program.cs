using System;
using Lab1.Model;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation sum = new Sum();
            
            Console.WriteLine(sum.ToString());
        }
    }
}

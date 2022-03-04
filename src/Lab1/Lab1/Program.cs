using Lab1.Model;
using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Function a = new LogarithmFunction(10);
            //Function b = new ConstantFunction(6);
            //Function c = new ExponentialFunction(1);
            Console.WriteLine(a.Derivative());
            //Console.WriteLine(b.Derivative());
            //Console.WriteLine(c.Derivative());
        }
    }
}

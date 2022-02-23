using System;

namespace PromProg1
{
    class Program
    {
        static void Main(string[] args)
        {
            Summation Sum1 = new Summation(1, 6);
            
            Console.WriteLine($"Hello World!\n{Sum1.GetResult()}");
        }
    }
}

using Lab1.Models;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] ars)
        {
            var test1 = new ConstantFunction(12);
            var test2 = new LinearFunction(1, 2);
            Console.WriteLine(test1.Constant);
            Console.WriteLine(test2.Linear.ToString());
            Console.WriteLine(test2.Constant.ToString());
        }

    }
}


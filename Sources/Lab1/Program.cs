using Lab1.Models;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] ars)
        {
            var test1 = new ConstantFunction(12);
            var test2 = new LinearFunction(1, 2);
            var test3 = new QuadraticFunction(1, 2, 3);
            var test4 = new SinusFunction(-1, 1, 0);
            var test5 = new CosinusFunction(1, 1, 0);
            Console.WriteLine("\n Entered Function: \n");
            Console.WriteLine(test1.ToString());
            Console.WriteLine(test2.ToString());
            Console.WriteLine(test3.ToString());
            Console.WriteLine(test4.ToString());
            Console.WriteLine(test5.ToString());
            Console.WriteLine("\n The Derivative Function bu Entered Function: \n");
            Console.WriteLine(test1.GetDerivative().ToString());
            Console.WriteLine(test2.GetDerivative().ToString());
            Console.WriteLine(test3.GetDerivative().ToString());
            Console.WriteLine(test4.GetDerivative().ToString());
            Console.WriteLine(test5.GetDerivative().ToString());
            Console.WriteLine("\n The Calculated Function bu Entered Function with number 10: \n");
            Console.WriteLine(test1.Calculate(10).ToString());
            Console.WriteLine(test2.Calculate(10).ToString());
            Console.WriteLine(test3.Calculate(10).ToString());
            Console.WriteLine(test4.Calculate(10).ToString());
            Console.WriteLine(test5.Calculate(10).ToString());
            Console.WriteLine("\n The Equals Function bu Entered Function: \n");
            Console.WriteLine(test5.GetDerivative().GetDerivative().ToString());
            Console.WriteLine(test4.Equals(test5.GetDerivative().GetDerivative()).ToString());

        }
    }
}


using System;
using System.Collections.Generic;
using Lab_1_Indust_Pr.Model;
using System.Linq;

namespace Lab_1_Indust_Pr
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Function gg = new Constant(2);
            Function gg1 = new Constant(3);
            Function gg2 = new Constant(4);
            Function gg3 = new Constant(5);

            Function lin = new LinearFunction(2, 8);
            //Console.WriteLine(lin.ToString());
            //Console.WriteLine(lin.GetValueFunc(2));
            //Console.WriteLine(lin.GetDerivative());
            //Console.WriteLine(lin);

            List<Function> func = new() { gg, gg1, lin, gg3};

            foreach (Function f in func)
            {
                Console.WriteLine(f);
            }

            var minValue = func.Min(x => x.GetDerivative().GetValueFunc(2));
            var funcMinValue = func.First(x => x.GetDerivative().GetValueFunc(2) == minValue);
            Console.WriteLine(funcMinValue);
            Console.WriteLine(GetMinValueDerivative(func, 2));
        }

        public static Function GetMinValueDerivative(List<Function> func, double arg)
        {
            if (func.Count == 0) throw new Exception("Your List is empty");
            double min = double.MaxValue;
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().GetValueFunc(arg) < min)
                    min = elem.GetDerivative().GetValueFunc(arg);
            }
            foreach (Function elem in func)
            {
                if (elem.GetDerivative().GetValueFunc(arg) == min)
                    return elem;
            }
            throw new Exception("Unreal ERROR");
        }
    }
}

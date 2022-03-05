using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    class QuadraticFunction : Function//ax^2 + bx + c
    {
        public double A;
        public double B;
        public double C;

        public QuadraticFunction(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        //2ax + b производная - линейная функция
        public override Function GetDerivative() => new LinearFunction(2 * A, B);

        public override double GetValueFunc(double arg) => A * Math.Pow(arg, 2) + B * arg + C;

        public override string ToString() => $"{A}x^2 + {B}x + {C}";
       
    }
}

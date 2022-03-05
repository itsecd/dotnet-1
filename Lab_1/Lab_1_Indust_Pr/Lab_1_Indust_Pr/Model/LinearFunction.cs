using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    class LinearFunction : Function // y = kx + b
    {
        public double K;
        public double B;
        public LinearFunction(double k, double b)
        {
            K = k;
            B = b;
            //B = new Constant(b);
        }

        public override double GetValueFunc(double arg) => K * arg + B;

        public override LinearFunction GetDerivative() => new LinearFunction(K, 0);

        public override string ToString() => $"{K}x + {B}";
    }
}

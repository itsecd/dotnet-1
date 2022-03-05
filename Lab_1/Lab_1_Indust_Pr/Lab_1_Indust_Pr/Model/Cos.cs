using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    class Cos : Function
    {
        public override Function GetDerivative()
        {
            var MySin = new Sin();
            MySin.Sign = false;
            return MySin;
        }

        public override double GetValueFunc(double arg) => Math.Cos(arg);

        public override string ToString() => $"Cos(x)";
    }
}

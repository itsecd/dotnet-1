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

        public override double GetValueFunc(double arg)
        {
            var x = arg * Math.PI / 180;
            return Math.Cos(x);
        }

        public override string ToString() => $"Cos(x)";

        public override bool Equals(object obj)
        {
            if (obj is Cos func)
                return true;
            return false;
        }

        public override int GetHashCode() => GetType().GetHashCode();
    }
}

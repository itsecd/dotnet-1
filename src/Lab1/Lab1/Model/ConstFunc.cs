using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class ConstFunc : Function
    {
        public override double getValue(double x = 0)
        {
            return Coef;
        }

        public override Function getDerivative()
        {
            return new ConstFunc(0);
        }

        public ConstFunc() : this(0)
        { }

        public ConstFunc(double _coef)
        {
            Coef = _coef;
            Name = "ConstFunc";
        }

        public override string ToString()
        {
            return $"f(x) = {Coef}";
        }
    }
}

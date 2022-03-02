using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class PowerFunc : Function // x^a
    {
        public override double getValue(double x = 0)
        {
            if (x == 0 && A < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return Coef * Math.Pow(x, A); // 0 нельзя возводить в отрицательные степени!
        }

        public override Function getDerivative()
        {
            return new PowerFunc(A - 1, A * Coef);
        }

        public PowerFunc() : this(0)
        { }

        public PowerFunc(double value, double _coef = 1)
        {
            A = value;
            Coef = _coef;
            Name = "PowerFunc";
        }

        public override string ToString()
        {
            return $"f(x) = x^({A})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class ExpoFunc : Function // a^x, не готово
    {
        public override double getValue(double x = 0)
        {
            if (A == 0 && x < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return Coef * Math.Pow(A, x); // 0 нельзя возводить в отрицательные степени!
        }

        public override Function getDerivative()
        {
            return new ExpoFunc(A, Math.Log(A, Math.E));
        }

        public ExpoFunc() : this(1)
        { }

        public ExpoFunc(double value, double _coef = 1)
        {
            A = value;
            Coef = _coef;
            Name = "ExpoFunc";
        }

        public override string ToString()
        {
            return $"f(x) = ({A})^x";
        }
    }
}

using System;

namespace Lab1.Model
{
    public class ExpoFunc : Function // a^x, не готово
    {
        public override double GetValue(double x = 0)
        {
            if (A == 0 && x < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return Coef * Math.Pow(A, x); // 0 нельзя возводить в отрицательные степени!
        }

        public override Function GetDerivative()
        {
            return new ExpoFunc(A, Math.Log(A, Math.E));
        }

        public ExpoFunc() : this(1)
        { }

        public ExpoFunc(double value, double coefficient = 1)
        {
            A = value;
            Coef = coefficient;
            Name = "ExpoFunc";
        }

        public override string ToString()
        {
            return $"f(x) = ({A})^x";
        }
    }
}

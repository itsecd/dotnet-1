using System;

namespace Lab1.Model
{
    public class PowerFunc : Function // x^a
    {
        public override double GetValue(double x = 0)
        {
            if (x == 0 && A < 0)
                return 0; 

            return Coef * Math.Pow(x, A); 
        }

        public override Function GetDerivative()
        {
            return new PowerFunc(A - 1, A * Coef);
        }

        public PowerFunc() : this(0)
        { }

        public PowerFunc(double value, double coefficient = 1)
        {
            A = value;
            Coef = coefficient;
            Name = "PowerFunc";
        }

        public override string ToString()
        {
            return $"f(x) = x^({A})";
        }
    }
}

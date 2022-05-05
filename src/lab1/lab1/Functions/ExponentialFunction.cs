using System;

namespace lab1.Functions
{
    public class ExponentialFunction : Function
    {
        public Double Exponent { get; set; }
        public Double Coefficient { get; set; }

        public ExponentialFunction()
        {
            Exponent = 1;
            Coefficient = 1;
        }

        public ExponentialFunction(double exponent, double coefficient)
        {
            Exponent = exponent;
            Coefficient = coefficient;
        }

        public override double Calculation(double x)
        {

            return Coefficient * Math.Pow(Exponent, x);
        }
        public override Function Derivative()
        {
            return new ExponentialFunction(Exponent, Coefficient * Math.Log(Exponent));
        }
        public override string ToString()
        {
            return $"y = {Coefficient} * {Exponent }^ x";
        }
        public override bool Equals(Object obj)
        {
            if (obj is not ExponentialFunction other)
                return false;
            return Exponent == other.Exponent && Coefficient == other.Coefficient;
        }
        public override int GetHashCode()
        {
            return Exponent.GetHashCode() + Coefficient.GetHashCode();
        }
    }
}

using System;

namespace Lab1.Functions
{
    public class Constant : Function
    {
        public double Coefficient { get; set; }

        public Constant()
        {
            Coefficient = 0;
        }

        public Constant(double data)
        {
            Coefficient = data;
        }

        public override double Calculation(double x)
        {
            return Coefficient;
        }

        public override Function Derivative()
        {
            return new Constant(0);
        }

        public override string ToString()
        {
            return $"y = {Coefficient}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Constant other)
                return false;
            return Coefficient == other.Coefficient;
        }

        public override int GetHashCode()
        {
            return Coefficient.GetHashCode();
        }
    }
}

using System;

namespace Lab1.Functions
{
    public class PowerFunction : Function
    {
        public double Degree { get; set; }
        public double Coefficient { get; set; }

        public PowerFunction()
        {
            Coefficient = 1;
            Degree = 1;
        }

        public PowerFunction(double coefficient, double degree)
        {
            Coefficient = coefficient;
            Degree = degree;
        }


        public override double Calculation(double x)
        {
            return Coefficient * Math.Pow(x, Degree);
        }

        public override Function Derivative()
        {
            return new PowerFunction(Coefficient * Degree, Degree - 1);
        }

        public override string ToString()
        {
            return $"y = {Coefficient} * x^{Degree}";
        }

        public override bool Equals(Object obj)
        {
            if (obj is not PowerFunction other)
                return false;
            return Coefficient == other.Coefficient && Degree == other.Degree;
        }

        public override int GetHashCode()
        {
            return Coefficient.GetHashCode() + Degree.GetHashCode();
        }
    }
}

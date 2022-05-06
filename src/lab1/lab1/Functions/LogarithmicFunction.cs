using System;

namespace Lab1.Functions
{
    public class LogarithmicFunction : Function
    {
        public double Base { get; set; }
        public double Coefficient { get; set; }

        public LogarithmicFunction()
        {
            Base = 10;
            Coefficient = 1;
        }

        public LogarithmicFunction(double baseNum, double coefficient)
        {
            Base = baseNum;
            Coefficient = coefficient;
        }

        public override double Calculation(double x)
        {
            return Coefficient * Math.Log(x, Base);
        }

        public override Function Derivative()
        {
            return new PowerFunction(1 / Math.Log(Base), -1);
        }

        public override string ToString()
        {
            return $"y = {Coefficient} * log_{Base} (x)";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not LogarithmicFunction other)
                return false;
            return Coefficient == other.Coefficient && Base == other.Base;
        }

        public override int GetHashCode()
        {
            return Coefficient.GetHashCode() + Base.GetHashCode();
        }
    }
}

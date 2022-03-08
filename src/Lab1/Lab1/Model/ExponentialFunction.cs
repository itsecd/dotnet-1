using System;

namespace Lab1.Model
{
    public class ExponentialFunction : Function
    {
        public double BaseOfDegree { get; set; }

        public ExponentialFunction()
        {
            BaseOfDegree = 0;
        }

        public ExponentialFunction(double baseOfDegree)
        {
            BaseOfDegree = baseOfDegree;
        }

        public override dynamic Calculate(double x)
        {
            if (BaseOfDegree <= 0 || BaseOfDegree == 1)
            {
                return "indefinitely";
            }
            return Math.Pow(BaseOfDegree, x);
        }

        public override string Derivative()
        {
            if (BaseOfDegree <= 0 || BaseOfDegree == 1)
            {
                return "y'= 0";
            }
            return $"y'= {BaseOfDegree}^x*{Math.Round(Math.Log(BaseOfDegree), 5)}";
        }

        public override string ToString()
        {
            return $"y = {BaseOfDegree}^x";
        }

        public override bool Equals(object obj)
        {
            if (obj is not ExponentialFunction other)
            {
                return false;
            }
            return BaseOfDegree == other.BaseOfDegree;
        }

        public override int GetHashCode()
        {
            return nameof(ExponentialFunction).GetHashCode();
        }
    }
}

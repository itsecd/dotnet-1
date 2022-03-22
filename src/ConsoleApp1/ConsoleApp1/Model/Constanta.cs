using System;
using ConsoleApp1.Model;

namespace ConsoleApp1.Model
{
    public class Constanta : Func
    {
        public double GetValue { get; set; } = 1;

        public Constanta() { }

        public Constanta(double value)
        {
            GetValue = value;
        }

        public override Func GetDerivative() => new Constanta(0);

        public override double Compute(double arg) => GetValue;

        public override string ToString() => $"{GetValue}";

        public override bool Equals(object? obj)
        {
            if (obj is Constanta c)
            {
                return GetValue == c.GetValue;
            }
            return false;
        }

        public override int GetHashCode() => GetValue.GetHashCode();
    }
}
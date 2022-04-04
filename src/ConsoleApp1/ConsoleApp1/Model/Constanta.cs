using System;
using ConsoleApp1.Model;

namespace ConsoleApp1.Model
{
    public class Constanta : Func
    {
        public double _value { get; init; } = 1;

        public Constanta() { }

        public Constanta(double value)
        {
            _value = value;
        }

        public override Func GetDerivative() => new Constanta(0);

        public override double Compute(double arg) => _value;

        public override string ToString() => $"{_value}";

        public override bool Equals(object obj)
        {
            if (obj is Constanta c)
            {
                return _value == c._value;
            }
            return false;
        }

        public override int GetHashCode() => (_value).GetHashCode();
    }
}
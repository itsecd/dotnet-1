using System;

namespace Model
{
    public class Constant : Function
    {
        private double Value { get; set; } = 1;
        public Constant(double value) { Value = value; }
        public Constant() { }
        public override Constant GetDerivative() { return new Constant(0); }
        public override double GetResult(double x) => Value;
        public override bool Equals(object obj)
        {
            if (obj is Constant func)
            {
                return Value == func.Value;
            }
            return false;
        }
        public override string ToString() => $"{Value}";

    }
}
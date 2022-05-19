using System;

namespace Model
{
    public class ExponentialFunction : Function
    {
        private double Value { get; set; } = 1;
        public ExponentialFunction(double value) { Value = value; }
        public ExponentialFunction() { }
        public override ExponentialFunction GetDerivative() { return new ExponentialFunction(0); }
        public override double GetResult(double x) { return Math.Exp(x); }
        public override bool Equals(object obj)
        {
            if (obj is ExponentialFunction func)
            {
                return Value == func.Value;
            }
            return false;
        }
        public override string ToString() => $"{Value}";

    }
}
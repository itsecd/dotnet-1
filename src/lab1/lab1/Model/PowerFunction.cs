using System;

namespace Model
{
    public class PowerFunction : Function
    {
        private double Value { get; set; } = 1;
        public PowerFunction(double value) { Value = value; }
        public PowerFunction() { }
        public override PowerFunction GetDerivative() { return new PowerFunction(0); }
        public override double GetResult(double x) => Value;
        public override bool Equals(object obj)
        {
            if ((obj is PowerFunction func) && (func.Value == Value))
            {
                return true;
            }
            return false;
        }
        public override string ToString() => $"{Value}";

    }
}
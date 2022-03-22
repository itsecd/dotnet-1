using System;

namespace ConsoleApp1.Model
{
    public class LinearFunc : Func 
    {
        public double Linear { get; set; } = 1;
        public double Const { get; set; } = 0;

        public LinearFunc() { }
        public LinearFunc(double linear, double constValue)
        {
            Linear = linear;
            Const = constValue;
        }

        public override double Compute(double arg) => Linear * arg + Const;

        public override Func GetDerivative() => new Constanta(Linear);

        public override string ToString() => $"{Linear}x + {Const}";

        public override bool Equals(object? obj)
        {
            if (obj is LinearFunc func)
            {
                return Linear == func.Linear && Const == func.Const;
            }
            return false;
        }

        public override int GetHashCode() => (Linear, Const).GetHashCode();
    }
}

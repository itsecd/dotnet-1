using System;

namespace prProgLab1.Model
{
    public class Sin : Function
    {
        public int X  { get; init; }

        public Sin() { }

        public Sin(int x)
        {
            X = x;
        }
        public override Function GetDerivative() => new Cos(X);

        public override string ToString() => $"Sin({X})";

        public override double GetValue(int x) => Math.Sin(X);

        public override bool Equals(object o) => o is Sin sin && sin.X == X;

        public override int GetHashCode() => X.GetHashCode();
    }
}

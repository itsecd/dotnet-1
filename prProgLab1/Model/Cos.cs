using System;

namespace prProgLab1.Model
{
    public class Cos : Function
    {
        public int X { get; init; }

        public Cos() { }

        public Cos(int x)
        {
            X = x;
        }
        public override Function GetDerivative() => new Sin(-X);

        public override string ToString() => $"Cos({X})";

        public override double GetValue(int x) => Math.Cos(X);

        public override bool Equals(object o) => o is Cos cos && cos.X == X;

        public override int GetHashCode() => X.GetHashCode();
    }
}

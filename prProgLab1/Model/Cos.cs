using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prProgLab1.Model
{
    public class Cos : Function
    {
        public int X;

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

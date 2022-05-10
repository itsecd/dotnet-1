using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prProgLab1.Model
{
    public class LinearFunction : Function
    {
        public int K { get; init; }
        public int B { get; init; }

        public LinearFunction() { }

        public LinearFunction(int k, int b)
        {
            K = k;
            B = b;
        }

        public override Function GetDerivative() => new Const(K);

        public override double GetValue(int x) => K * x + B;

        public override string ToString() => K + " * x " + (B >= 0 ? " + " + B : " - " + B);

        public override bool Equals(object o) => o is LinearFunction linearFunction
            && linearFunction.K == K && linearFunction.B == B;

        public override int GetHashCode() => (K, B).GetHashCode();
    }
}

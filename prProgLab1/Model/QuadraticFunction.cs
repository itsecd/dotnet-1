using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prProgLab1.Model
{
    public class QuadraticFunction : Function
    {
        public int A { get; init; }
        public int B { get; init; }
        public int C { get; init; }

        public QuadraticFunction() { }

        public QuadraticFunction(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
        public override Function GetDerivative() => new LinearFunction(A, B);

        public override string ToString() => A + " * (x ^ 2) " + (B > 0 ? " + " + B : " - " + B) + " * x " + (C > 0 ? " + " + C : " - " + C);

        public override double GetValue(int x) => A * (x * x) + B * x + C;

        public override bool Equals(object o) => o is QuadraticFunction quadraticFunction 
            && quadraticFunction.A == A && quadraticFunction.B == B && quadraticFunction.C == C;

        public override int GetHashCode() => (A, B, C).GetHashCode();
    }
}

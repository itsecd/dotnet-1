using System;
using System.Linq;


namespace Lab1.Models
{
    public class LinearFunction : Function
    {
        public double Linear { get; init; }
        public double Constant { get; init; }

        public LinearFunction() {
            Linear = 1;
            Constant = 0;
        }

        public LinearFunction(double linear, double constant) {
            Linear = linear;
            Constant = constant;
        }

        public override double Calculate(double x)
            => Linear * x + Constant;

        public override Function GetDerivative()
            => new ConstantFunction(Linear);

        public override Function GetAntiderivative()
            => new QuadraticFunction(Linear, Constant, 0);

        public override bool Equals(Function? obj)
        {
            if (obj is not LinearFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Linear, 3) == Math.Round(f.Linear, 3);
        }

        public override string ToString()
        {
            string result = "";

            if (Linear != 0)
                result += $"{Linear}x ";

            if (Constant != 0)
                result += Constant > 0
                    ? $"+ {Constant}x "
                    : $"- {Math.Abs(Constant)}x ";

            return result;
        }

        public override int GetHashCode()
            => HashCode.Combine(Linear, Constant);
    }
}

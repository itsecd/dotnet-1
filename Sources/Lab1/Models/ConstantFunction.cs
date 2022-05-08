using System;

namespace Lab1.Models
{
    public class ConstantFunction : Function
    {
        public double Constant { get; init;  }

        public ConstantFunction() { }

        public ConstantFunction(double constant)
            => Constant = constant;

        public override double Calculate(double x)
            => Constant;

        public override Function GetDerivative()
            => new ConstantFunction();

        public override Function GetAntiderivative()
            => new LinearFunction(Constant, 0);

        public override bool Equals(Function? obj)
        {
            if (obj is not ConstantFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3);
        }

        public override string ToString()
            => Constant.ToString();

        public override int GetHashCode()
            => HashCode.Combine(Constant);
    }
}

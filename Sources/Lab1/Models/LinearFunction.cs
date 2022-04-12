using System;
using System.Linq;


namespace Lab1.Models
{
    public class LinearFunction : Function
    {
        public double Linear { get; }
        public double Constant { get; }

        public LinearFunction() {
            Linear = 1;
            Constant = 0;
        }

        public LinearFunction(double linear, double constant)
        {
            Linear = linear;
            Constant = constant;
        }

        public override double Calculate(double x)
            => Linear * x + Constant;

        public override Function GetDerivative()
            => new ConstantFunction(Linear);

        public override bool Equals(Function? obj)
        {
            if (obj is not LinearFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Linear, 3) == Math.Round(f.Linear, 3);
        }

        public override string ToString()
        {
            if (Constant > 0)
                return $"{Linear} {"x + "} {Constant}".ToString();
            if (Constant < 0)
                return $"{Linear} {"x - "} {Math.Abs(Constant)}".ToString();
            return $"{Linear} {"x "}".ToString();
        }
    }
}

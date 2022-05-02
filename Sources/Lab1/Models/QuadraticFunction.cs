namespace Lab1.Models
{
    public class QuadraticFunction : Function
    {

        public double Quadratic { get; init; }
        public double Linear { get; init; }
        public double Constant { get; init; }

        public QuadraticFunction()
        {
            Quadratic = 1;
            Linear = 0;
            Constant = 0;
        }

        public QuadraticFunction(double quadratic, double linear, double constant)
        {
            Quadratic = quadratic;
            Linear = linear;
            Constant = constant;
        }

        public override double Calculate(double x)
            => Quadratic * x * x + Linear * x + Constant;

        public override Function GetDerivative()
            => new LinearFunction(Quadratic, Linear);

        public override Function GetAntiderivative()
            => new CubicFunction(Quadratic, Linear, Constant, 0);

        public override bool Equals(Function? obj)
        {
            if (obj is not QuadraticFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Linear, 3) == Math.Round(f.Linear, 3) &&
                Math.Round(Quadratic, 3) == Math.Round(f.Quadratic, 3);
        }

        public override string ToString()
        {
            string result = "";

            if (Quadratic != 0)
                result += $"{Quadratic}x^2 ";

            if (Linear != 0)
                result += Linear > 0
                    ? $"+ {Linear}x "
                    : $"- {Math.Abs(Linear)}x ";

            if (Constant != 0)
                result += Constant > 0
                    ? $"+ {Constant}x "
                    : $"- {Math.Abs(Constant)}x ";

            return result;
        }

        public override int GetHashCode()
            => HashCode.Combine(Quadratic, Linear, Constant);
    }
}
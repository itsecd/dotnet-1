namespace Lab1.Models
{
    public class CubicFunction : Function
    {

        public double Cubic { get; init; }
        public double Quadratic { get; init; }
        public double Linear { get; init; }
        public double Constant { get; init; }

        public CubicFunction()
        {
            Quadratic = 1;
            Quadratic = 0;
            Linear = 0;
            Constant = 0;
        }
        public CubicFunction(double cubic, double quadratic, double linear, double constant)
        {
            Cubic = cubic;
            Quadratic = quadratic;
            Linear = linear;
            Constant = constant;
        }

        public override double Calculate(double x)
            => Cubic * x * x + Quadratic * x * x + Linear * x + Constant;

        public override Function GetDerivative()
            => new QuadraticFunction(Cubic, Quadratic, Linear);

        public override Function GetAntiderivative()
            => new CubicFunction(Cubic, Quadratic, Linear, Constant);

        public override bool Equals(Function? obj)
        {
            if (obj is not CubicFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Linear, 3) == Math.Round(f.Linear, 3) &&
                Math.Round(Quadratic, 3) == Math.Round(f.Quadratic, 3) &&
                Math.Round(Cubic, 3) == Math.Round(f.Cubic, 3);
        }

        public override string ToString()
        {
            string result = "";
            switch(Cubic)
            {
                case  0:
                    break;
                default:
                    result += $"{Cubic}x^3 ";
                    break;
            }
            switch (Quadratic)
            {
                case 0:
                    break;
                case >0:
                    result += $"+ {Quadratic}x^2 ";
                    break;
                case < 0:
                    result += $"- {Math.Abs(Quadratic)}x^2 ";
                    break;
            }

            switch (Linear)
            {
                case 0:
                    break;
                case > 0:
                    result += $"+ {Linear}x ";
                    break;
                case < 0:
                    result += $"- {Math.Abs(Linear)}x ";
                    break;
            }

            switch (Constant)
            {
                case 0:
                    break;
                case > 0:
                    result += $"+ {Constant}x ";
                    break;
                case < 0:
                    result += $"- {Math.Abs(Constant)}x ";
                    break;
            }
            return result;
        }

        public override int GetHashCode()
            => HashCode.Combine(Quadratic, Linear, Constant);
    }
}
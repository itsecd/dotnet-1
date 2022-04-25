namespace Lab1.Models
{
    public class QuadraticFunction: Function
    {

        public double Quadratic { get; }
        public double Linear { get; }
        public double Constant { get; }

        public QuadraticFunction() { }

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
            if (Linear > 0)
            {
                if (Constant > 0)
                    return $"{Quadratic} {"x^2 + "} {Linear} {"x + "}{Constant}".ToString();
                if (Constant < 0)
                    return $"{Quadratic} {"x^2 + "} {Linear} {"x - "}{Math.Abs(Constant)}".ToString();
                return $"{Quadratic} {"x^2 + "} {Linear} {"x "}".ToString();
            }
            if (Linear < 0)
            {
                if (Constant > 0)
                    return $"{Quadratic} {"x^2 - "} {Math.Abs(Linear)} {"x + "}{Constant}".ToString();
                if (Constant < 0)
                    return $"{Quadratic} {"x^2 - "} {Math.Abs(Linear)} {"x - "}{Math.Abs(Constant)}".ToString();
                return $"{Quadratic} {"x^2 - "} {Math.Abs(Linear)} {"x "}".ToString();
            }
            if (Constant > 0)
                return $"{Quadratic} {"x^2 + "} {Constant}".ToString();
            if (Constant < 0)
                return $"{Quadratic} {"x^2 - "} {Math.Abs(Constant)}".ToString();
            return $"{Quadratic} {"x^2 "}".ToString();
        }

        public override int GetHashCode()
            => HashCode.Combine(Quadratic, Linear, Constant);
    }
}
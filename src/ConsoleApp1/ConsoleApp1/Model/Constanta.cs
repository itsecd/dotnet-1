namespace ConsoleApp1.Model
{
    public class Constanta : Func
    {
        public double Value { get; init; } = 1;

        public Constanta() { }

        public Constanta(double value)
        {
            Value = value;
        }

        public override Func GetDerivative() => new Constanta(0);

        public override double Compute(double arg) => Value;

        public override string ToString() => $"{Value}";

        public override bool Equals(object obj)
        {
            if (obj is Constanta c)
            {
                return Value == c.Value;
            }
            return false;
        }

        public override int GetHashCode() => (Value).GetHashCode();
    }
}
namespace Lab1.Model
{
    public class Constant : Function
    {
        public double ValueConst { get; set; } = 1;

        public Constant() { }

        public Constant(double value)
        {
            ValueConst = value;
        }

        public override Constant GetDerivative() => new Constant(0);

        public override double Compute(double arg) => ValueConst;

        public override string ToString() => $"{ValueConst}";

        public override bool Equals(object? obj)
        {
            if (obj is Constant c)
            {
                return ValueConst == c.ValueConst;
            }
            return false;
        }

        public override int GetHashCode() => ValueConst.GetHashCode();
    }
}

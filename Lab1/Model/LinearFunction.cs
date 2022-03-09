namespace Lab1.Model
{
    public class LinearFunction : Function // y = kx + b
    {
        public double Linear { get; } = 1;
        public double Const { get; } = 0;
        
        public LinearFunction() { }
        public LinearFunction(double linear, double constValue)
        {
            Linear = linear;
            Const = constValue;
        }

        public override double Compute(double arg) => Linear * arg + Const;

        public override Function GetDerivative() => new Constant(Linear);

        public override string ToString() => $"{Linear}x + {Const}";

        public override bool Equals(object obj)
        {
            if (obj is LinearFunction func)
            {
                return Linear == func.Linear && Const == func.Const;
            }
            return false;
        }

        public override int GetHashCode() => (Linear, Const).GetHashCode();
    }
}

namespace Lab1.Models
{
    public class SinusFunction: Function
    {
        public double Constant { get; init; }
        public double Angle { get; init; }
        public double Phase { get; init; }

        public SinusFunction() {
            Constant = 1;
            Angle = Math.PI/2;
            Phase = 0;
        }

        public SinusFunction(double constant, double angle, double phase)
        {
            Constant = constant;
            Angle = angle;
            Phase = phase;
        }

        public override double Calculate(double x)
            => Constant * Math.Cos(Angle * x + Phase);

        public override Function GetDerivative()
            => new CosinusFunction(Constant * Angle, Angle, Phase);

        public override bool Equals(Function? obj)
        {
            if (obj is not SinusFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Angle, 3) == Math.Round(f.Angle, 3) &&
                Math.Round(Phase, 3) == Math.Round(f.Phase, 3);
        }

        public override string ToString()
        {
            if (Phase == 0)
                return $"{Constant}{"sin("}{Angle}{"x)"}".ToString();
            if (Constant > 0)
                return $"{Constant}{"sin("}{Angle}{"x + "}{Phase}{")"}".ToString();
            return $"{Constant}{"sin("}{Angle}{"x - "}{Phase}{")"}".ToString();
        }

        public override int GetHashCode()
            => HashCode.Combine(Constant, Angle, Phase);
    }
}
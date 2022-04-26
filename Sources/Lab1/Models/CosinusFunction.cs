namespace Lab1.Models
{
    public class CosinusFunction: Function
    {
        public double Constant { get; init; }
        public double Angle { get; init; }
        public double Phase { get; init; }

        public CosinusFunction()
        {
            Constant = 1;
            Angle = 0;
            Phase = 0;
        }

        public CosinusFunction(double constant, double angle, double phase)
        {
            Constant = constant;
            Angle = angle;
            Phase = phase;
        }

        public override double Calculate(double x)
            => Constant * Math.Cos(Angle * x + Phase);

        public override Function GetDerivative()
            => new SinusFunction(-Constant*Angle, Angle, Phase);

        public override bool Equals(Function? obj)
        {
            if (obj is not CosinusFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Angle, 3) == Math.Round(f.Angle, 3) &&
                Math.Round(Phase, 3) == Math.Round(f.Phase, 3);
        }

        public override string ToString()
        {
            if (Phase == 0)
                return $"{Constant}{"cos("}{Angle}".ToString();
            if (Constant > 0)
                return $"{Constant}{"cos("}{Angle}{"x +"} {Phase}{" )"}".ToString();
            return $"{Constant}{"cos("} {Angle}{"x -"} {Phase}{" )"}".ToString();
        }
    }
}
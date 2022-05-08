namespace Lab1.Models
{
    public class CosineFunction: Function
    {
        public double Constant { get; init; }
        public double Angle { get; init; }
        public double Phase { get; init; }

        public CosineFunction()
        {
            Constant = 1;
            Angle = 0;
            Phase = 0;
        }

        public CosineFunction(double constant, double angle, double phase)
        {
            Constant = constant;
            Angle = angle;
            Phase = phase;
        }

        public override double Calculate(double x)
            => Constant * Math.Cos(Angle * x + Phase);

        public override Function GetDerivative()
            => new SineFunction(-Constant*Angle, Angle, Phase);

        public override Function GetAntiderivative()
            => new SineFunction(Constant, Angle, Phase);

        public override bool Equals(Function? obj)
        {
            if (obj is not CosineFunction f)
                return false;

            return Math.Round(Constant, 3) == Math.Round(f.Constant, 3) &&
                Math.Round(Angle, 3) == Math.Round(f.Angle, 3) &&
                Math.Round(Phase, 3) == Math.Round(f.Phase, 3);
        }

        public override string ToString()
        {
            string result = "";
            if (Constant == 0)
            {
                result = "0";
                return result;
            }
            result = $"{Constant}cos(";

            if (Angle != 0)
                result += $"{Angle}x";

            if (Phase != 0)
                result += Phase > 0
                    ? $" + {Phase}"
                    : $" - {Math.Abs(Phase)}";

            result += ")";
            return result;
        }
    }
}
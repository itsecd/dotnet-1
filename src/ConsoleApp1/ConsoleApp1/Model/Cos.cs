using System;


namespace ConsoleApp1.Model
{
    public class Cos : Func
    {
        public double Amplitude { get; init; } = 1;
        public double Omega { get; init; } = 1;
        public double Phase { get; init; } = 1;

        public Cos() { }

        public Cos(double amplitude, double omega, double phase)
        {
            Amplitude = amplitude;
            Omega = omega;
            Phase = phase;
        }

        public override Func GetDerivative() => new Sin(-Amplitude * Omega, Omega, Phase);

        public override double Compute(double arg) => Amplitude * Math.Cos(Omega * arg + Phase);

        public override string ToString() => $"{Amplitude} cos({Omega}x + {Phase})";

        public override bool Equals(object obj)
        {
            if (obj is Cos func)
            {
                return Amplitude == func.Amplitude && Omega == func.Omega && Phase == func.Phase;
            }
            return false;
        }

        public override int GetHashCode() => (Amplitude, Omega, Phase).GetHashCode();
    }
}
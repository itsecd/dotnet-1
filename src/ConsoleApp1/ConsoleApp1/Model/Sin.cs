using System;

namespace ConsoleApp1.Model
{
    public class Sin : Func
    {
        public double Amplitude { get; init; } = 1;
        public double Omega { get; init; } = 1;
        public double Phase { get; init; } = 1;

        public Sin() { }

        public Sin(double amplitude, double omega, double phase)
        {
            Amplitude = amplitude;
            Omega = omega;
            Phase = phase;
        }

        public override Func GetDerivative() => new Cos(Amplitude * Omega, Omega, Phase);

        public override double Compute(double arg) => Amplitude * Math.Sin(Omega * arg + Phase);

        public override string ToString() => $"{Amplitude} sin({Omega}x + {Phase})";

        public override bool Equals(object obj)
        {
            if (obj is Sin func)
            {
                return Amplitude == func.Amplitude && Omega == func.Omega && Phase == func.Phase;
            }
            return false;
        }

        public override int GetHashCode() => (Amplitude, Omega, Phase).GetHashCode();
    }
}
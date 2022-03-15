using System;

namespace Lab1.Model
{
    public class Sin : Function
    {
        public double Amplitude { get; } = 1;
        public double Omega { get; } = 1;
        public double Phase { get; } = 1;

        public Sin() { }

        public Sin(double amplitude, double omega, double phase)
        {
            Amplitude = amplitude;
            Omega = omega;
            Phase = phase;
        }

        public override Function GetDerivative() => new Cos(Amplitude * Omega, Omega, Phase);

        public override double Compute(double arg) => Amplitude * Math.Sin(Omega*arg + Phase);

        public override string ToString() => $"{Amplitude} sin({Omega}x + {Phase}";

        public override bool Equals(object? obj)
        {
            if (obj is Sin func)
            {
                return Amplitude == func.Amplitude && Omega == func.Omega && Phase == func.Phase;
            }
            return false;
        }

        public override int GetHashCode() => GetType().GetHashCode();
    }
}

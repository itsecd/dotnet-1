namespace Lab1.Model
{
    class Cos : Function
    {
        public double Amplitude { get; } = 1;
        public double Omega { get; } = 1;
        public double Phase { get; } = 1;

        public Cos(double amplitude, double omega, double phase)
        {
            Amplitude = amplitude;
            Omega = omega;
            Phase = phase;
        }

        public override Function GetDerivative() => new Sin(-Amplitude*Omega, Omega, Phase);

        public override double Compute(double arg) => Amplitude * Math.Cos(Omega * arg + Phase);

        public override string ToString() => $"{Amplitude} cos({Omega}x + {Phase}";
            
        public override bool Equals(object obj)
        {
            if (obj is Cos func)
                return true;
            return false;
        }

        public override int GetHashCode() => GetType().GetHashCode();
    }
}

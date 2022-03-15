using System;

namespace Lab1.Model
{
    public class Cos : Function
    {
        public double Amplitude { get; } = 1;
        public double Omega { get; } = 1;
        public double Phase { get; } = 1;

        public Cos() { }

        public Cos(double amplitude, double omega, double phase)
        {
            Amplitude = amplitude;
            Omega = omega;
            Phase = phase;
        }

        public override Function GetDerivative() => new Sin(-Amplitude*Omega, Omega, Phase);

        public override double Compute(double arg) => Amplitude * Math.Cos(Omega * arg + Phase);

        public override string ToString() => $"{Amplitude} cos({Omega}x + {Phase}";
            
        /*
        var s = объект?.поле
        если объект равен null, то переменная s будет содержать null вместо генерации исключения.
        var s = объект.поле ?? стандартное_значение
        если объект равен null, то вернется стандартное_значение.
        */
        public override bool Equals(object? obj)
        {
            if (obj is Cos func)
            {
                return Amplitude == func.Amplitude && Omega == func.Omega && Phase == func.Phase;
            }
            return false;
        }

        public override int GetHashCode() => GetType().GetHashCode();
    }
}

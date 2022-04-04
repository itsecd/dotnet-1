using System;

namespace ConsoleApp1.Model
{
    public class Sin : Func
    {
        public double _amplitude { get; init; } = 1;
        public double _omega { get; init; } = 1;
        public double _phase { get; init; } = 1;

        public Sin() { }

        public Sin(double amplitude, double omega, double phase)
        {
            _amplitude = amplitude;
            _omega = omega;
            _phase = phase;
        }

        public override Func GetDerivative() => new Cos(_amplitude * _omega, _omega, _phase);

        public override double Compute(double arg) => _amplitude * Math.Sin(_omega * arg + _phase);

        public override string ToString() => $"{_amplitude} sin({_omega}x + {_phase})";

        public override bool Equals(object obj)
        {
            if (obj is Sin func)
            {
                return _amplitude == func._amplitude && _omega == func._omega && _phase == func._phase;
            }
            return false;
        }

        public override int GetHashCode() => (_amplitude, _omega, _phase).GetHashCode();
    }
}
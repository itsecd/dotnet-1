using System;

namespace ConsoleApp1.Model
{
    public class QuadrFunc : Func
    {
        public double _quadratic { get; init; } = 1;
        public double _linear { get; init; } = 1;
        public double _const { get; init; } = 1;

        public QuadrFunc() { }
        public QuadrFunc(double a, double b, double c)
        {
            _quadratic = a;
            _linear = b;
            _const = c;
        }

        
        public override Func GetDerivative() => new LinearFunc(2 * _quadratic, _linear);

        public override double Compute(double arg) => _quadratic * Math.Pow(arg, 2) + _linear * arg + _const;

        public override string ToString() => $"{_quadratic}x^2 + {_linear}x + {_const}";

        public override bool Equals(object obj)
        {
            if (obj is QuadrFunc func)
            {
                return _quadratic == func._quadratic && _linear == func._linear && _const == func._const;
            }
            return false;
        }

        public override int GetHashCode() => (_quadratic, _linear, _const).GetHashCode();

    }
}
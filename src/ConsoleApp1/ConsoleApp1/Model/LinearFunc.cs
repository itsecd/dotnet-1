using System;

namespace ConsoleApp1.Model
{
    public class LinearFunc : Func 
    {
        public double _linear { get; init; } = 1;
        public double _const { get; init; } = 0;

        public LinearFunc() { }
        public LinearFunc(double linear, double constValue)
        {
            _linear = linear;
            _const = constValue;
        }

        public override double Compute(double arg) => _linear * arg + _const;

        public override Func GetDerivative() => new Constanta(_linear);

        public override string ToString() => $"{_linear}x + {_const}";

        public override bool Equals(object obj)
        {
            if (obj is LinearFunc func)
            {
                return _linear == func._linear && _const == func._const;
            }
            return false;
        }

        public override int GetHashCode() => (_linear, _const).GetHashCode();
    }
}

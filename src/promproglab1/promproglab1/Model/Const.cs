﻿namespace promproglab1.Model
{
    class Const : Function
    {
        public double A { get; init; }

        public Const(double a)
        {
            A = a;
        }

        public override double GetValue(double x)
        {
            return A;
        }

        public override Function GetDerivative()
        {
            return new Const(0);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Const other)
                return false;  
            return A == other.A;
        }

        public override string ToString()
        {
            return ($"y = {A}");
        }
    }
}

using System;

namespace Lab1.Model
{
    public class Logarithm : Function
    {
        public Data Elems { get; init; }

        public Logarithm() { Elems = new Data(); }

        public Logarithm(Data elems)
        {
            Elems = new Data(elems._a, elems._coeff);
        }
        public Logarithm(int basis, int coefficient)
        {
            Elems = new Data(basis, coefficient);
        }

        public override double? Calculation(double value)
        {
            if (value < 0)
                return null;
            return Elems._coeff * Math.Round(Math.Log(value, Elems._a), 2);
        }

        public override string Derivative()
        {
            if (Elems._a < 1)
                return "indefinitely";
            else if (Elems._coeff == 0)
                return "y' = 0";
            else
                return $"y' = {Math.Round(Elems._coeff / Math.Log(Elems._a), 2)} x^-1";
        }

        public override string ToString()
        {
            if (Elems._a < 1)
                return "incorrect base";

            return Elems._coeff switch
            {
                1 => $"y = log_{Elems._a}x",
                0 => "y = 0",
                _ => $"y = {Elems._coeff} log_{Elems._a}x"
            };
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Logarithm other)
                return false;
            return Elems._coeff == other.Elems._coeff && Elems._a == other.Elems._a;
        }

        public override int GetHashCode()
        {
            return Elems._a.GetHashCode() ^ Elems._coeff.GetHashCode();
        }
    }
}
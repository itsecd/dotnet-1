using System;

namespace Lab1.Model
{
    public class Logarithm : Function
    {
        public Data Elems { get; init; }

        public Logarithm() { Elems = new Data(); }

        public Logarithm(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }
        public Logarithm(int basis, int coefficient)
        {
            Elems = new Data(basis, coefficient);
        }

        public override double? Calculation(double value)
        {
            if (value < 0)
                return null;
            return Elems.Coeff * Math.Round(Math.Log(value, Elems.A), 2);
        }

        public override string Derivative()
        {
            if (Elems.A < 1)
                return "indefinitely";
            else if (Elems.Coeff == 0)
                return "y' = 0";
            else
                return $"y' = {Math.Round(Elems.Coeff / Math.Log(Elems.A), 2)} x^-1";
        }

        public override string ToString()
        {
            if (Elems.A < 1)
                return "incorrect base";

            return Elems.Coeff switch
            {
                1 => $"y = log_{Elems.A}x",
                0 => "y = 0",
                _ => $"y = {Elems.Coeff} log_{Elems.A}x"
            };
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Logarithm other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }

        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}
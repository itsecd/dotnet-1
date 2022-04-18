using System;

namespace Lab1.Model
{
    public class Exponential : Function
    {
        public Data Elems { get; init; }

        public Exponential() { Elems = new Data(); }

        public Exponential(Data elems)
        {
            Elems = new Data(elems._a, elems._coeff);
        }

        public Exponential(int exponent, int coefficient)
        {
            Elems = new Data(exponent, coefficient);
        }

        public override double? Calculation(double value)
        {
            if (value < 0)
                return null;
            return Elems._coeff * Math.Pow(Elems._a, value);
        }
        public override string Derivative()
        {
            if (Elems._a < 0)
                return "indefinitely";
            else if (Elems._coeff == 1)
                return $"y' = {Math.Round(Math.Log(Elems._a), 2)}*{Elems._a}^x ";
            else if (Elems._coeff == 0)
                return "y' = 0";
            else if (Elems._a == 0)
                return "y' = 0";
            else
                return $"y' = {Math.Round(Elems._coeff * Math.Log(Elems._a), 2)}*{Elems._a}^x ";
        }
        public override string ToString()
        {
            return Elems._coeff switch
            {
                1 => $"y = {Elems._a}^x",
                0 => "y = 0",
                _ => $"y = {Elems._coeff}*{Elems._a}^x"
            };
        }
        public override bool Equals(Object obj)
        {
            if (obj is not Exponential other)
                return false;
            return Elems._coeff == other.Elems._coeff && Elems._a == other.Elems._a;
        }
        public override int GetHashCode()
        {
            return Elems._a.GetHashCode() ^ Elems._coeff.GetHashCode();
        }
    }
}
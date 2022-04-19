using System;

namespace Lab1.Model
{
    public class Exponential : Function
    {
        public Data Elems { get; init; }

        public Exponential() { Elems = new Data(); }

        public Exponential(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public Exponential(int exponent, int coefficient)
        {
            Elems = new Data(exponent, coefficient);
        }

        public override double? Calculation(double value)
        {
            if (value < 0)
                return null;
            return Elems.Coeff * Math.Pow(Elems.A, value);
        }
        public override string Derivative()
        {
            if (Elems.A < 0)
                return "indefinitely";
            else if (Elems.Coeff == 1)
                return $"y' = {Math.Round(Math.Log(Elems.A), 2)}*{Elems.A}^x ";
            else if (Elems.Coeff == 0)
                return "y' = 0";
            else if (Elems.A == 0)
                return "y' = 0";
            else
                return $"y' = {Math.Round(Elems.Coeff * Math.Log(Elems.A), 2)}*{Elems.A}^x ";
        }
        public override string ToString()
        {
            return Elems.Coeff switch
            {
                1 => $"y = {Elems.A}^x",
                0 => "y = 0",
                _ => $"y = {Elems.Coeff}*{Elems.A}^x"
            };
        }
        public override bool Equals(Object obj)
        {
            if (obj is not Exponential other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }
        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}
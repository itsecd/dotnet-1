using System;

namespace Lab1.Model
{
    public class Power : Function
    {
        public Data Elems { get; init; }

        public Power() { Elems = new Data(); }

        public Power(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public Power(int power, int coefficient)
        {
            Elems = new Data(power, coefficient);
        }

        public override double? Calculation(double value)
        {
            return Elems.Coeff * Math.Pow(value, Elems.A);
        }

        public override string Derivative()
        {
            if (Elems.Coeff == 0)
                return "y' = 0";
            switch (Elems.A)
            {
                case 1:
                    return $"y' = {Elems.Coeff * Elems.A}";

                case 0:
                    return "y' = 0";

                default:
                    return $"y' = { Elems.Coeff * Elems.A}x^{Elems.A - 1}";
            }
        }

        public override string ToString()
        {
            return Elems.Coeff switch
            {
                1 => $"y = x^{Elems.A}",
                0 => "y = 0",
                _ => $"y = {Elems.Coeff}x^{Elems.A}"
            };
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Power other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }

        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}
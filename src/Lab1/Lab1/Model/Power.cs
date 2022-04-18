using System;

namespace Lab1.Model
{
    public class Power : Function
    {
        public Data Elems { get; init; }

        public Power() { Elems = new Data(); }

        public Power(Data elems)
        {
            Elems = new Data(elems._a, elems._coeff);
        }

        public Power(int power, int coefficient)
        {
            Elems = new Data(power, coefficient);
        }

        public override double? Calculation(double value)
        {
            return Elems._coeff * Math.Pow(value, Elems._a);
        }

        public override string Derivative()
        {
            if (Elems._coeff == 0)
                return "y' = 0";
            switch (Elems._a)
            {
                case 1:
                    return $"y' = {Elems._coeff * Elems._a}";

                case 0:
                    return "y' = 0";

                default:
                    return $"y' = { Elems._coeff * Elems._a}x^{Elems._a - 1}";
            }
        }

        public override string ToString()
        {
            return Elems._coeff switch
            {
                1 => $"y = x^{Elems._a}",
                0 => "y = 0",
                _ => $"y = {Elems._coeff}x^{Elems._a}"
            };
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Power other)
                return false;
            return Elems._coeff == other.Elems._coeff && Elems._a == other.Elems._a;
        }

        public override int GetHashCode()
        {
            return Elems._a.GetHashCode() ^ Elems._coeff.GetHashCode();
        }
    }
}
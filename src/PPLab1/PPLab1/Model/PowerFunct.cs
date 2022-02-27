using System;

namespace PPLab1.Model
{
    public class PowerFunct : Function
    {
        public Data Elems { get; init; }

        public PowerFunct() { Elems = new Data(); }

        public PowerFunct(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public PowerFunct(int A, int Coeff)
        {
            Elems = new Data(A, Coeff);
        }

        public override double? CalculationFunction(double value)
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
            switch (Elems.Coeff)
            {
                case 1:
                    return $"y = x^{Elems.A}";

                case 0:
                    return "y = 0";

                default:
                    return $"y = {Elems.Coeff}x^{Elems.A}";
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj is not PowerFunct other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }

        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}


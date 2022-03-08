using System;

namespace PPLab1.Model
{
    public class ExpFunct : Function
    {
        public Data Elems { get; init; }

        public ExpFunct() { Elems = new Data(); }

        public ExpFunct(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public ExpFunct(int exponent, int coefficient)
        {
            Elems = new Data(exponent, coefficient);
        }

        public override double? CalculationFunction(double value)
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
                return $"y' = {Math.Round(Math.Log(Elems.A), 2)}*{Elems.A}^x " ;
            else if (Elems.Coeff == 0)
                return "y' = 0";
            else if (Elems.A == 0)
                return "y' = 0";
            else
                return $"y' = {Math.Round(Elems.Coeff * Math.Log(Elems.A), 2)}*{Elems.A}^x " ;
        }
        public override string ToString()
        {
            switch (Elems.Coeff)
            {
                case 1:
                    return $"y = {Elems.A}^x";

                case 0:
                    return "y = 0";

                default:
                    return $"y = {Elems.Coeff}*{Elems.A}^x";
            }
        }
        public override bool Equals(Object obj)
        {
            if (obj is not ExpFunct other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }
        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}


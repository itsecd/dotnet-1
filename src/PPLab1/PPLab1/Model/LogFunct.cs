using System;

namespace PPLab1.Model
{
    public class LogFunct : Function
    {
        public Data Elems { get; init; }

        public LogFunct() { Elems = new Data(); }

        public LogFunct(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }
        public LogFunct(int A, int Coeff)
        {
            Elems = new Data(A, Coeff);
        }

        public override double? CalculationFunction(double value)
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
            
            switch (Elems.Coeff)
            {
                case 1:
                    return $"y = log_{Elems.A}x";

                case 0:
                    return "y = 0";

                default:
                    return $"y = {Elems.Coeff} log_{Elems.A}x";
            }  
        }

        public override bool Equals(Object obj)
        {
            if (obj is not LogFunct other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.A == other.Elems.A;
        }

        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}


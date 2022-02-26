using System;

namespace PPLab1.Model
{
    public class LogFunct : Function
    {
        public Data Elems { get; set; }

        public LogFunct() { Elems = new Data(); }

        public LogFunct(Data elems) { Elems = elems; }

        public LogFunct(int A, int Coeff)
        {
            Elems = new Data(A, Coeff);
        }

        public override double? calc_funct(double value)
        {
            if (value < 0)
                return null; 
            return Elems.Coeff * Math.Round(Math.Log(value, Elems.A), 2);
        }
        public override string derivative()
        {
            if (Elems.A < 1)
                return "indefinitely";
            else if (Elems.Coeff == 0)
                return String.Format("y' = 0");
            else
                return String.Format("y' = {0} x^-1", Math.Round(Elems.Coeff / Math.Log(Elems.A), 2));
        }
        public override string ToString()
        {
            if (Elems.A < 1)
                return "incorrect base";
            else if (Elems.Coeff == 1)
                return String.Format("y =  log_{0}x", Elems.A);
            else if (Elems.Coeff == 0)
                return String.Format("y = 0");
            else
                return String.Format("y = {0} log_{1}x", Elems.Coeff, Elems.A);
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


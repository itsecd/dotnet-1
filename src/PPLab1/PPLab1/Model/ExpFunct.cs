using System;

namespace PPLab1.Model
{
    public class ExpFunct : Function
    {
        public Data Elems { get; set; }

        public ExpFunct() { Elems = new Data(); }

        public ExpFunct(Data elems) { Elems = elems; }

        public ExpFunct(int A, int Coeff)
        {
            Elems = new Data(A, Coeff);
        }

        public override double? calc_funct(double value)
        {
            if (value < 0)
                return null;
            return Elems.Coeff * Math.Pow(Elems.A, value);
        }
        public override string derivative()
        {
            if (Elems.A < 0)
                return "indefinitely";
            else if (Elems.Coeff == 1)
                return String.Format("y' = {0}*{1}^x ",
                Math.Round(Math.Log(Elems.A), 2), Elems.A);
            else if (Elems.Coeff == 0)
                return String.Format("y' = 0");
            else if (Elems.A == 0)
                return String.Format("y' = 0");
            else
                return String.Format("y' = {0}*{1}^x ",
                Math.Round(Elems.Coeff * Math.Log(Elems.A), 2), Elems.A);
        }
        public override string ToString()
        {
            if(Elems.Coeff == 1)
                return String.Format("y = {0}^x", Elems.A);
            else if(Elems.Coeff == 0)
                return String.Format("y = 0");
            else 
                return String.Format("y = {0}*{1}^x", Elems.Coeff, Elems.A);
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


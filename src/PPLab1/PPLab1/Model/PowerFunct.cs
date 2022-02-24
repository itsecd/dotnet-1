using System;

namespace PPLab1.Model
{
    public class PowerFunct : Function
    {
        public Data Elems { get; set; }

        public PowerFunct() { Elems = new Data(); }

        public PowerFunct(Data elems) { Elems = elems; }

        public PowerFunct(int A, int Coeff)
        {
            Elems = new Data(A, Coeff);
        }

        public override double? calc_funct(double value)
        {
            return Elems.Coeff * Math.Pow(value, Elems.A);
        }
        public override string derivative()
        {
            if (Elems.Coeff == 0)
                return String.Format("y' = 0");
            else if(Elems.A == 0)
                return String.Format("y' = 0");
            else if (Elems.A == 1)
                return String.Format("y' = {0}", Elems.Coeff * Elems.A);
            else
                return String.Format("y' = {0}x^{1}", Elems.Coeff * Elems.A, Elems.A - 1);
        }
        public override string ToString()
        {
            if (Elems.Coeff == 1)
                return String.Format("y = x^{0}", Elems.A);
            else if (Elems.Coeff == 0)
                return String.Format("y = 0");
            else
                return String.Format("y = {0}x^{1}", Elems.Coeff, Elems.A);
        }
        public override bool Equals(Object obj)
        {
            if (obj is PowerFunct)
            {
                PowerFunct pf = (PowerFunct)obj;
                return (Elems.Coeff == pf.Elems.Coeff) && (Elems.A == pf.Elems.A);
            }
            else { return false; }
        }
        public override int GetHashCode()
        {
            return Elems.A.GetHashCode() ^ Elems.Coeff.GetHashCode();
        }
    }
}


using System;

namespace PPLab1.Model
{
    public class Const : Function
    {
        public Data Elems { get; set; }

        public Const() { Elems = new Data(); }

        public Const(Data elems) { Elems = elems; }

        public Const(int Coeff) 
        { 
            Elems = new Data(1, Coeff);
        }

        public override double? calc_funct(double value) { return Elems.Coeff; }

        public override string derivative() { return "y' = 0"; }

        public override string ToString()
        {
            return String.Format("y = {0}", Elems.Coeff);
        }

        public override bool Equals(Object obj)
        {
            if (obj is Const)
            {
                Const c = (Const)obj;
                return(Elems.Coeff == c.Elems.Coeff);
            }
            else { return false; }
        }

        public override int GetHashCode()
        {
            return Elems.Coeff.GetHashCode();
        }
    }
}




using System;

namespace PPLab1.Model
{
    internal class PowerFunct : Function
    {
        public Data Elems { get; set; }

        public PowerFunct() { Elems = new Data(); }

        public PowerFunct(Data elems) { Elems = elems; }

        public override double calc_funct(double value)
        {
            return Elems.K * Math.Pow(value, Elems.A);
        }
        public override string derivative()
        {
            return String.Format("y' = {0}x^{1}", Elems.K*Elems.A, Elems.A - 1);
        }
        public override string ToString()
        {
            return String.Format("y = {0}x^{1}", Elems.K, Elems.A);
        }
    }
}


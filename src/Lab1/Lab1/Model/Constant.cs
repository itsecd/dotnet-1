using System;

namespace Lab1.Model
{
    public class Constant : Function
    {
        public Data Elems { get; init; }

        public Constant() { Elems = new Data(); }

        public Constant(Data elems)
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public Constant(int coefficient)
        {
            Elems = new Data(1, coefficient);
        }

        public override double? Calculation(double value) { return Elems.Coeff; }

        public override string Derivative() { return "y' = 0"; }

        public override string ToString()
        {
            return ($"y = {Elems.Coeff}");
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Constant other)
                return false;
            return Elems.Coeff == other.Elems.Coeff;
        }

        public override int GetHashCode()
        {
            return Elems.Coeff.GetHashCode();
        }
    }
}
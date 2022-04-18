using System;

namespace Lab1.Model
{
    public class Constant : Function
    {
        public Data Elems { get; init; }

        public Constant() { Elems = new Data(); }

        public Constant(Data elems)
        {
            Elems = new Data(elems._a, elems._coeff);
        }

        public Constant(int coefficient)
        {
            Elems = new Data(1, coefficient);
        }

        public override double? Calculation(double value) { return Elems._coeff; }

        public override string Derivative() { return "y' = 0"; }

        public override string ToString()
        {
            return ($"y = {Elems._coeff}");
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Constant other)
                return false;
            return Elems._coeff == other.Elems._coeff;
        }

        public override int GetHashCode()
        {
            return Elems._coeff.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Functions
{
    public class Constant : Function
    {
        public Data Elems { get; init; }

        public Constant() { Elems = new Data(); }

        public Constant(Data elems)
        {
            Elems = new Data(elems.X, elems.Coeff);
        }
        public override double? Calculation() 
        { 
            return Elems.Coeff; 
        }

        public override string Derivative() 
        { 
            return "y' = 0"; 
        }

        public override string ToString()
        {
            return $"y = {Elems.Coeff}";
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

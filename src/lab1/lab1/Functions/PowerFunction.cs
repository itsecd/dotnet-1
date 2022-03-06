using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Functions
{
    class PowerFunction: Function
    {
        public Data Elems { get; init; }

        public PowerFunction() { Elems = new Data(); }

        public PowerFunction(Data elems)
        {
            Elems = new Data(elems.X, elems.Coeff, elems.Degree);
        }

        public override double? Calculation()
        {
            return Elems.Coeff * Math.Pow(Elems.X, Elems.Degree);
        }

        public override string Derivative()
        {
            if (Elems.Coeff == 0)
                return "y' = 0";
            else if (Elems.Degree == 0)
                return "y' = 0";
            else
                return $"y' = { Elems.Coeff * Elems.Degree}x^{Elems.Degree - 1}";
        }

        public override string ToString()
        { 
            if(Elems.Coeff==0)
                return "y = 0";
            else
                return $"y = {Elems.Coeff}x^{Elems.Degree}";
        }

        public override bool Equals(Object obj)
        {
            if (obj is not PowerFunction other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.X == other.Elems.X && Elems.Degree == other.Elems.Degree;
        }

        public override int GetHashCode()
        {
            return Elems.X.GetHashCode() ^ Elems.Coeff.GetHashCode() ^ Elems.Degree.GetHashCode();
        }
    }
}

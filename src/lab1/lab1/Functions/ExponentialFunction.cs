using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Functions
{
    class ExponentialFunction: Function
    {
        public Data Elems { get; init; }

        public ExponentialFunction() { Elems = new Data(); }

        public ExponentialFunction(Data elems)
        {
            Elems = new Data(elems.X, elems.Coeff, elems.Degree);
        }

        public override double? Calculation()
        {
            if (Elems.X < 0)
                return null;
            return Elems.Coeff * Math.Pow(Elems.Degree, Elems.X);
        }
        public override string Derivative()
        {
            if (Elems.X < 0)
                return "indefinitely";
            else if (Elems.Coeff == 0)
                return "y' = 0";
            else if (Elems.Degree == 0)
                return "y' = 0";
            else
                return $"y' = {Elems.Coeff * Math.Log(Elems.Degree)}*{Elems.Degree}^x ";
        }
        public override string ToString()
        {
            if (Elems.Coeff == 0)
                return "y = 0";
            else
                return $"y = {Elems.Coeff}*{Elems.Degree}^x";
        }
        public override bool Equals(Object obj)
        {
            if (obj is not ExponentialFunction other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.X == other.Elems.X && Elems.Degree == other.Elems.Degree;
        }
        public override int GetHashCode()
        {
            return Elems.X.GetHashCode() ^ Elems.Coeff.GetHashCode() ^ Elems.Degree.GetHashCode();
        }
    }
}

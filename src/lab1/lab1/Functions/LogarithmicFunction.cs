using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Functions
{
    class LogarithmicFunction: Function
    {
        public Data Elems { get; init; }

        public LogarithmicFunction() { Elems = new Data(); }

        public LogarithmicFunction(Data elems)
        {
            Elems = new Data(elems.X, elems.Coeff, elems.Degree);
        }

        public override double? Calculation()
        {
            if (Elems.X < 0)
                return null;
            return Elems.Coeff * Math.Log(Elems.X, Elems.Degree);
        }

        public override string Derivative()
        {
            if (Elems.Degree == 1 || Elems.Degree <= 0 || Elems.X <= 0)
                return "indefinitely";
            else if (Elems.Coeff == 0)
                return "y' = 0";
            else
                return $"y' = ({Elems.Coeff / Math.Log(Elems.Degree)})/x";
        }

        public override string ToString()
        {
            if (Elems.Degree == 1 || Elems.Degree <= 0 || Elems.X <= 0)
                return "indefinitely";
            if (Elems.Coeff == 0)
                return "y = 0";
            else
                return $"y = {Elems.Coeff} log_{Elems.Degree}x";
        }

        public override bool Equals(Object obj)
        {
            if (obj is not LogarithmicFunction other)
                return false;
            return Elems.Coeff == other.Elems.Coeff && Elems.X == other.Elems.X && Elems.Degree == other.Elems.Degree;
        }

        public override int GetHashCode()
        {
            return Elems.X.GetHashCode() ^ Elems.Coeff.GetHashCode() ^ Elems.Degree.GetHashCode();
        }
    }
}

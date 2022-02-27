using System;
using Spectre.Console;

namespace PPLab1.Model
{
    public class Const : Function
    {
        public Data Elems { get; init; }

        public Const() { Elems = new Data(); }

        public Const(Data elems) 
        {
            Elems = new Data(elems.A, elems.Coeff);
        }

        public Const(int Coeff) 
        { 
            Elems = new Data(1, Coeff);
        }

        public override double? CalculationFunction(double value) { return Elems.Coeff; }

        public override string Derivative() { return "y' = 0"; }

        public override string ToString()
        {
            return ($"y = {Elems.Coeff}");
        }

        public override bool Equals(Object obj)
        {
            if (obj is not Const other)
                return false;
            return Elems.Coeff == other.Elems.Coeff;
        }

        public override int GetHashCode()
        {
            return Elems.Coeff.GetHashCode();
        }
    }
}




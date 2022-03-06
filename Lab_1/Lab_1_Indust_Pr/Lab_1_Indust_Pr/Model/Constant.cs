using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    class Constant : Function
    {
        public double ValueConst { get; set; } = 1;

        public Constant(double value)
        {
            ValueConst = value;
        }

        public override Constant GetDerivative() => new Constant(0);//производная

        public override double GetValueFunc(double arg) => 0.0;
        
        public override string ToString() => $"{ValueConst}";

        public override bool Equals(object obj)
        {
            if (obj is Constant c)
            {
                return ValueConst == c.ValueConst;
            }
            return false;
        }

        public override int GetHashCode() => ValueConst.GetHashCode();
    }
}

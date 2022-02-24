using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Div : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first / second);

        public override bool Equals(object obj)
        {
            if (obj is not Div)
                return false;
            else
                return true;
        }

        public override int GetHashCode() => nameof(Div).GetHashCode();

        public override string ToString() => "integer division";
    }
}

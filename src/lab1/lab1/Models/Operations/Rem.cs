using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Rem : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first % second);

        public override bool Equals(object obj)
        {
            if (obj is not Rem)
                return false;
            else
                return true;
        }

        public override int GetHashCode() => nameof(Rem).GetHashCode();

        public override string ToString() => "remainder of division";
    }
}

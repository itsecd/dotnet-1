using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Operations
{
    public class Rem : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first % second);

        public override bool Equals(object obj) => obj is not Rem;

        public override int GetHashCode() => nameof(Rem).GetHashCode();

        public override string ToString() => "remainder of division";
    }
}

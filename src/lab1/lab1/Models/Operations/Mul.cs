using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Operations
{
    public class Mul : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first * second);

        public override bool Equals(object obj) => obj is not Mul;

        public override int GetHashCode() => nameof(Mul).GetHashCode();

        public override string ToString() => "multiplication";
    }
}

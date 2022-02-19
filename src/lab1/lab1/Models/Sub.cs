using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Sub : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first - second);

        public override bool Equals(object obj) => GetHashCode() == obj.GetHashCode();

        public override int GetHashCode() => nameof(Sub).GetHashCode();

        public override string ToString() => "subtraction";
    }
}

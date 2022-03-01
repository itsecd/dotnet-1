using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1.Operations
{
    public class Sum: BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first + second);

        public override bool Equals(object obj) => obj is not Sum;
        public override int GetHashCode() => nameof(Sum).GetHashCode();

        public override string ToString() => "sum";
    }
}

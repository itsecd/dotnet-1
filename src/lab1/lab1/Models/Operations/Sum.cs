using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1
{
    public class Sum: BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first + second);

        public override bool Equals(object obj)
        {
            if (obj is not Sum)
                return false;
            else
                return true;
        }

        public override int GetHashCode() => nameof(Sum).GetHashCode();

        public override string ToString() => "sum";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    abstract class BinaryOperation 
    {
        public abstract IntOperand Calculate(IntOperand first, IntOperand second);

        public abstract override int GetHashCode()
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}

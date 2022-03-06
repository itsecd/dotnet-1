using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Functions
{
    public abstract class Function
    {
        public abstract double? Calculation();
        public abstract string Derivative();
        public abstract override string ToString();
        public abstract override bool Equals(Object obj);
        public abstract override int GetHashCode();
    }
}

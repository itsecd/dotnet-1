using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromProg1
{
    public abstract class Operation
    {
        public abstract double GetResult();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        //public abstract override int GetHashCode();
    }
}

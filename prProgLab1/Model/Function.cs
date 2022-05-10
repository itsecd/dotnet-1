using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prProgLab1.Model
{
    public abstract class Function
    {
        public abstract double GetValue(int x);
        public abstract Function GetDerivative();
        public abstract override string ToString();
        public abstract override bool Equals(object o);
        public abstract override int GetHashCode();
    }
}

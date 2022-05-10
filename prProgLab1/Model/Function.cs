using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prProgLab1.Model
{
    [XmlInclude(typeof(Const))]
    [XmlInclude(typeof(LinearFunction))]
    [XmlInclude(typeof(QuadraticFunction))]
    [XmlInclude(typeof(Sin))]
    [XmlInclude(typeof(Cos))]
    public abstract class Function
    {
        public abstract double GetValue(int x);
        public abstract Function GetDerivative();
        public abstract override string ToString();
        public abstract override bool Equals(object o);
        public abstract override int GetHashCode();
    }
}

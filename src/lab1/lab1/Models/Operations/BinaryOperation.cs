using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1
{
    [XmlInclude(typeof(Sum))]
    [XmlInclude(typeof(Div))]
    [XmlInclude(typeof(Sub))]
    [XmlInclude(typeof(Mul))]
    [XmlInclude(typeof(Rem))]
    [Serializable]
    public abstract class BinaryOperation 
    {
        public abstract IntOperand Calculate(IntOperand first, IntOperand second);

        public abstract override int GetHashCode();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}

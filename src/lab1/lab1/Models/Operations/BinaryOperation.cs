using System;
using System.Xml.Serialization;

namespace Lab1.Operations
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

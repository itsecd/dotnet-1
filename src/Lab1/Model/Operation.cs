using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Sum))]
    [XmlInclude(typeof(Sub))]
    [XmlInclude(typeof(Mul))]
    [XmlInclude(typeof(IntDiv))]
    [XmlInclude(typeof(DivRemainder))]

    public abstract class Operation
    {
        public abstract int Compute(int lhs, int rhs);

        public abstract override bool Equals(object? obj);

        public abstract override int GetHashCode();

        public abstract override string ToString();

    }
}
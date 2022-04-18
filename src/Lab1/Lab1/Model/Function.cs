using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Constant))]
    [XmlInclude(typeof(Exponential))]
    [XmlInclude(typeof(Logarithm))]
    [XmlInclude(typeof(Power))]

    public abstract class Function
    {
        public abstract double? Calculation(double value);
        public abstract string Derivative();
        public abstract override string ToString();
        public abstract override bool Equals(Object obj);
        public abstract override int GetHashCode();
    }
}

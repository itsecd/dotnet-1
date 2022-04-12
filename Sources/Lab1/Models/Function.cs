using System;
using System.Xml.Serialization;


namespace Lab1.Models
{
    [XmlInclude(typeof(ConstantFunction))]
    [XmlInclude(typeof(LinearFunction))]
    [XmlInclude(typeof(SinusFunction))]
    [XmlInclude(typeof(CosinusFunction))]
    public abstract class Function :
        IEquatable<Function>
    {
        public abstract double Calculate(double x);
        public abstract Function GetDerivative();
        public abstract bool Equals(Function? other);
        public abstract override string ToString();
    }
}

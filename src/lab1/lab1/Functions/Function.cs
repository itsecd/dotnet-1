using System;
using System.Xml.Serialization;

namespace lab1.Functions
{
    [XmlInclude(typeof(Constant))]
    [XmlInclude(typeof(PowerFunction))]
    [XmlInclude(typeof(ExponentialFunction))]
    [XmlInclude(typeof(LogarithmicFunction))]
    [Serializable]
    public abstract class Function
    {
        public abstract double Calculation(double x);
        public abstract Function Derivative();
        public abstract override string ToString();
        public abstract override bool Equals(Object obj);
        public abstract override int GetHashCode();
    }

    public enum FunctionType
    {
        Constant,
        Exponential,
        Power,
        Logarithmic
    }
}

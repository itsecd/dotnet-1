using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Const))]
    [XmlInclude(typeof(ExpFunct))]
    [XmlInclude(typeof(LogFunct))]
    [XmlInclude(typeof(PowerFunct))]

    public abstract class Function
    {
        public abstract double? CalculationFunction(double value);
        public abstract string Derivative();
        public abstract override string ToString();
        public abstract override bool Equals(Object obj);
        public abstract override int GetHashCode();
    }
}

using System.Xml.Serialization;

namespace PromProg1.Models
{
    [XmlInclude(typeof(Summation))]
    [XmlInclude(typeof(Subtraction))]
    [XmlInclude(typeof(Multiplication))]
    [XmlInclude(typeof(Remainder))]
    [XmlInclude(typeof(IntegerDivision))]
    public abstract class Operation
    {
        public abstract double GetResult(double operand1, double operand2);
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}

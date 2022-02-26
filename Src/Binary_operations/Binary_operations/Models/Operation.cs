using System.Xml.Serialization;

namespace Binary_operations.Models
{
    [XmlInclude(typeof(Addition))]
    [XmlInclude(typeof(Division))]
    [XmlInclude(typeof(Multyplication))]
    [XmlInclude(typeof(Remainder))]
    [XmlInclude(typeof(Substraction))]

    public abstract class Operation
    { 
        public abstract int GetResult(int left, int right);
    }
}

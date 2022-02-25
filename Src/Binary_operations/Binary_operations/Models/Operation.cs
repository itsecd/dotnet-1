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
      public int Lhs { get; set;}
      public int Rhs { get; set; }

        public abstract int GetResult(int left, int right);
    }
}

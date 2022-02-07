using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Square))]
    public abstract class Figure
    {
        public abstract double GetLength();
    }
}

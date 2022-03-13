using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    public abstract class Figure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Rectangle GetMinFramingRectangle();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}
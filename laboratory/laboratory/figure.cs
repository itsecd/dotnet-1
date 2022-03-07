using System;
using System.Xml.Serialization;
namespace laboratory.model
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    public abstract class Figure : IEquatable<Figure>
    {
        public abstract Rectangle FramingRectangle();
        public abstract double Perimeter();
        public abstract double Square();
        public abstract override string ToString();
        public abstract override int GetHashCode();
        public abstract bool Equals(Figure other);
    }
}

using Lab1.Model;
using System;
using System.Xml.Serialization;
namespace Lab1
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    public abstract class Figure : IEquatable<Figure>
    {
        public abstract Rectangle FramingRectangle();

        public abstract double Perimeter();

        public abstract double Area();

        public abstract override string ToString();

        public abstract override int GetHashCode();

        public abstract bool Equals(Figure? other);
    }
}

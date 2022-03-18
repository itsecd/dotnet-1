using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    public abstract class Figure
    {
        public abstract double GetPerimeter();

        public abstract double GetArea();

        public abstract Rectangle GetBounds();
    }
}

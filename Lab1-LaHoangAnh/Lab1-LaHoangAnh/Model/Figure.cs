using System.Xml.Serialization;

namespace Lab1.Mode
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Tritangle))]
    [XmlInclude(typeof(Circle))]
    public abstract class Figure
    {
        public abstract double Perimeter();
        public abstract double Square();
        public abstract Rectangle MinBoundingFigure();

    }
}

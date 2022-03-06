using Lab1.Shapes;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Cylinder))]
    [XmlInclude(typeof(Ball))]
    [XmlInclude(typeof(RectangularParallelepiped))]
    public abstract class Figure
    {
        public abstract double GetVolume();
        public abstract double GetSurfaceArea();
        public abstract RectangularParallelepiped GetMinimalFramingParalelepiped();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}

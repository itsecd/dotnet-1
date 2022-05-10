using System.Xml.Serialization;

namespace Lab1_3D.Model
{
    [XmlInclude(typeof(Sphere))]
    [XmlInclude(typeof(RectangularParallelepiped))]
    [XmlInclude(typeof(Cylinder))]
    public abstract class Figure3D
    {
        public abstract double GetSurfaceArea();
        public abstract int GetVolume();

        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract RectangularParallelepiped GetMinParallelepiped();
        public abstract override int GetHashCode();
    }
}

using System.Xml.Serialization;

namespace Laba1.Model
{
    [XmlInclude(typeof(Sphere))]
    [XmlInclude(typeof(RectangularParallelepiped))]
    [XmlInclude(typeof(Cylinder))]
    public abstract class Figure3D
    {

        public abstract double GetArea();
        public abstract double GetVolume();
        /// <summary>
        /// Finding the minimum framing rectangular parallelepiped.
        /// </summary>
        /// <returns>Minimal framing rectangular parallelepiped.</returns>
        public abstract RectangularParallelepiped GetMinParallelepiped();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);

    }
}

using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangular))]
    [XmlInclude(typeof(Sphere))]
    [XmlInclude(typeof(Cylinder))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double GetSurfaceArea();

        public abstract double GetVolume();

        public abstract Rectangular GetBoundingBox();
    }
}

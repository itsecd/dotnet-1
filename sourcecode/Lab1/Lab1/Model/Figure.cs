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
        public abstract double SurfaceArea();

        public abstract double volume();
    }
}

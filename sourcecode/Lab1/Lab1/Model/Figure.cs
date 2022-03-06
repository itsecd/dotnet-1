using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangular))]
    [XmlInclude(typeof(Globular))]
    [XmlInclude(typeof(Cylinder))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double acreage();

        public abstract double volume();
    }
}

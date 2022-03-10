using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Tritangle))]
    [XmlInclude(typeof(Circle))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double Perimeter();
        public abstract double Square();
        public abstract Rectangle MinBoundingFigure();

    }
}

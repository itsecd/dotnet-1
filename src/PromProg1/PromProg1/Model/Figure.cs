using System;
using System.Xml.Serialization;

namespace PromProg1
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double Square();
        public abstract double Perimeter();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract Rectangle FramingRectangle();


    }
}
using System;
using System.Xml.Serialization;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.Model
{
    [XmlInclude(typeof(RectangularCuboid))]
    [XmlInclude(typeof(Sphere))]
    [XmlInclude(typeof(Cylinder))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double GetSquare();
        public abstract double GetPerimeter();    
        public abstract RectangularCuboid GetMinCuboid();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}

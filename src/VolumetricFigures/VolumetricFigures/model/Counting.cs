using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VolumetricFigures.model.figures;

namespace VolumetricFigures.model
{
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(RectangularCuboid))]
    [XmlInclude(typeof(Sphere))]
    [XmlInclude(typeof(Cylinder))]
    [Serializable]
    public abstract class Counting
    {
        public abstract double GetSquare();
        public abstract double GetPerimeter();    
        public abstract RectangularCuboid GetMinCuboid();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}

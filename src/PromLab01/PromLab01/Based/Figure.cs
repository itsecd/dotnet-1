using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PromLab01
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]
    [Serializable]
    public abstract class Figure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Rectangle GetBorders();
        public override abstract string ToString();
    }
}

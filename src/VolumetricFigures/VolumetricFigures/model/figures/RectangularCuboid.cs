using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VolumetricFigures.model.figures
{
    [Serializable]
    [XmlRoot("RectangularCuboid")]
    public class RectangularCuboid : Counting
    {
        [XmlElement("Point_1")]
        public Point _p1 { get; set; }
        [XmlElement("Point_2")]
        public Point _p2 { get; set; }

        public RectangularCuboid()
        {
        }

        public RectangularCuboid(Point p1, Point p2)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public double GetWidht()
        {
            return Math.Abs(_p1.x - _p2.x);
        }

        public double GetLength()
        {
            return Math.Abs(_p1.y - _p2.y);
        }

        public double GetHight()
        {
            return Math.Abs(_p1.z - _p2.z);
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(_p1.x, _p1.y, _p1.z ),
                new Point(_p2.x, _p2.y, _p2.z )
                );
        }

        public override double GetPerimeter()
        {
            return 2 * (GetHight() * GetWidht() + GetWidht() * GetLength() + GetLength() * GetHight());
        }

        public override double GetSquare()
        {
            return GetHight() * GetWidht() * GetLength();
        }

        public override string ToString()
        {
            return "1: " + _p1.ToString() + "2: " + _p2.ToString();
        }

        public override bool Equals(Object obj)
        {
            RectangularCuboid rectangularCuboid = obj as RectangularCuboid;
            return rectangularCuboid._p1.Equals(_p1) && 
                rectangularCuboid._p2.Equals(_p2);
        }

        public override int GetHashCode()
        {
            return _p1.GetHashCode() ^ _p2.GetHashCode();
        }
    }
}

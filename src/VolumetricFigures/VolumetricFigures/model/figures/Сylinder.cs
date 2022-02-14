using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VolumetricFigures.model.figures
{
    [Serializable]
    [XmlRoot("Cylinder")]
    public class Cylinder : Counting
    {
        [XmlElement("Point")]
        public Point _centreFoundation { get; set; }
        [XmlElement("Radius")]
        public double _radius { get; set; }
        [XmlElement("Height")]
        public double _height { get; set; }

        public Cylinder()
        {
        }

        public Cylinder(Point centreFoundation, double radius, double height)
        {
            _centreFoundation = centreFoundation;
            _radius = radius;
            _height = height;
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(_centreFoundation.x + _radius, _centreFoundation.y + _radius, _centreFoundation.z), 
                new Point( _centreFoundation.x - _radius, _centreFoundation.y - _radius, _centreFoundation.z + _height )
                );
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius * (_height + _radius);
        }

        public override double GetSquare()
        {
            return Math.PI * Math.Pow(_radius, 2) * _height;
        }
        public override string ToString()
        {
            return "Centre: " + _centreFoundation.ToString() + "Radius: " + _radius + "\nHeight: " + _height;
        }

        public override bool Equals(Object obj)
        {
            Cylinder cylinder = obj as Cylinder;
            return cylinder._centreFoundation.Equals(_centreFoundation) &&
                cylinder._radius == _radius &&
                cylinder._height == _height;
        }

        public override int GetHashCode()
        {
            return _centreFoundation.GetHashCode() ^ _radius.GetHashCode() ^ _height.GetHashCode();
        }
    }
}

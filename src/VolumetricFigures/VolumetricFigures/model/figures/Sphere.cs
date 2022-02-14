using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VolumetricFigures.model.figures
{
    [Serializable]
    [XmlRoot("Sphere")]
    public class Sphere : Counting
    {
        [XmlElement("Point")]
        public Point _centre { get; set; }
        [XmlElement("Radius")]
        public double _radius { get; set; }

        public Sphere()
        {
        }

        public Sphere(Point centre, double radius)
        {
            _centre = centre;
            _radius = radius;
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(_centre.x + _radius , _centre.y + _radius, _centre.z + _radius ), 
                new Point( _centre.x - _radius, _centre.y - _radius, _centre.z - _radius )
                );
        }

        public override double GetPerimeter()
        {
            return 4 * Math.PI * Math.Pow(_radius, 2);
        }

        public override double GetSquare()
        {
            return (4/3) * Math.PI * Math.Pow(_radius, 3);
        }

        public override string ToString()
        {
            return "Centre: " + _centre.ToString() + "Radius: " + _radius;
        }

        public override bool Equals(Object obj)
        {
            Sphere sphere = obj as Sphere;
            return sphere._centre.Equals(_centre) && 
                sphere._radius == _radius;
        }

        public override int GetHashCode()
        {
            return _centre.GetHashCode() ^ _radius.GetHashCode();
        }
    }
}

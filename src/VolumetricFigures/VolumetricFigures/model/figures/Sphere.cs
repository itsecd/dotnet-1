using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumetricFigures.model.figures
{
    public class Sphere : Counting
    {

        private Point _centre;
        private double _radius { get; set; }

        public Sphere(Point centre, double radius)
        {
            _centre = centre;
            _radius = radius;
        }

        public override double[,] GetMinCuboid()
        {
            return new double[2, 3] { { _centre.x + _radius , _centre.y + _radius, _centre.z + _radius }, { _centre.x - _radius, _centre.y - _radius, _centre.z - _radius } };
        }

        public override double GetPerimeter()
        {
            return 4 * Math.PI * _radius * _radius;
        }

        public override double GetSquare()
        {
            return (4/3) * Math.PI * _radius * _radius * _radius;
        }

        public override string ToString()
        {
            return "Centre: " + _centre.ToString() + "Radius: " + _radius;
        }

        public override bool Equals(Object obj)
        {
            Sphere sphere = obj as Sphere;
            Сylinder сylinder = obj as Сylinder;
            return sphere._centre.Equals(_centre) && sphere._radius == _radius;
        }
    }
}

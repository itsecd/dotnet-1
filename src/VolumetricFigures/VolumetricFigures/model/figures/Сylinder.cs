using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumetricFigures.model.figures
{
    public class Сylinder:Counting
    {

        private Point _centreFoundation;
        private double _radius { get; set; }
        private double _height { get; set; }

        public Сylinder(Point centreFoundation, double radius, double height)
        {
            _centreFoundation = centreFoundation;
            _radius = radius;
            _height = height;
        }

        public override double[,] GetMinCuboid()
        {
            return new double[2, 3] { { _centreFoundation.x + _radius, _centreFoundation.y + _radius, _centreFoundation.z}, { _centreFoundation.x - _radius, _centreFoundation.y - _radius, _centreFoundation.z + _height } };
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius * (_height + _radius);
        }

        public override double GetSquare()
        {
            return Math.PI * _radius * _radius * _height;
        }
        public override string ToString()
        {
            return "Centre: " + _centreFoundation.ToString() + "Radius: " + _radius + "\nHeight: " + _height;
        }

        public override bool Equals(Object obj)
        {
            Сylinder сylinder = obj as Сylinder;
            return сylinder._centreFoundation.Equals(_centreFoundation) && сylinder._height==_height && сylinder._radius==_radius;
        }
    }
}

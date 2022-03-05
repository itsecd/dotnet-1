using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Shapes
{
    public class Ball : Figure
    {

        public Point _centre { get; set; }

        public int _radius { get; set; }

        public Ball()
        {
            _radius = 0;
            _centre = new Point();
        }

        public Ball(Point centre, int radius)
        {
            _centre = centre;
            _radius = radius;
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(_centre._x + _radius, _centre._y + _radius, _centre._z + _radius),
                new Point(_centre._x - _radius, _centre._y - _radius, _centre._z- _radius)
                );
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(_radius, 2);
        }

        public override double GetVolume()
        {
            return 4 / 3.0 * Math.PI * Math.Pow(_radius, 3);
        }

        public override string ToString()
        {
            return "Centre: " + _centre + "Radius: " + _radius;
        }

        public override bool Equals(Object obj)
        {
            try
            {
                Ball sphere = obj as Ball;
                return sphere._centre.Equals(_centre) &&
                    sphere._radius == _radius;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public override int GetHashCode()
        {
            return _centre.GetHashCode() ^ _radius.GetHashCode();
        }

    }
}

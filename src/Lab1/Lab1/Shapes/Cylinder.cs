using Lab1.Model;
using System;

namespace Lab1.Shapes
{
    public class Cylinder : Figure
    {

        public Point _centre { get; set; }

        public int _radius { get; set; }

        public int _height { get; set; }

        public Cylinder()
        {
            _radius = 0;
            _height = 0;
            _centre = new Point();
        }

        public Cylinder(Point centre, int radius, int height)
        {
            _centre = centre;
            _radius = radius;
            _height = height;
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(_centre._x + _radius, _centre._y + _radius, _centre._z),
                new Point(_centre._x - _radius, _centre._y - _radius, _centre._z + _height)
                );
        }

        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * _radius * (_height + _radius);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(_radius, 2) * _height;
        }
        public override string ToString()
        {
            return "Centre: " + _centre + "Radius: " + _radius + "\nHeight: " + _height;
        }

        public override bool Equals(Object obj)
        {
            try
            {
                Cylinder cylinder = obj as Cylinder;
                return cylinder._centre.Equals(_centre) &&
                    cylinder._radius == _radius &&
                    cylinder._radius == _radius;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public override int GetHashCode()
        {
            return _centre.GetHashCode() ^ _radius.GetHashCode() ^ _height.GetHashCode();
        }
    }
}

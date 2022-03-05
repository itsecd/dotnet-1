using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Shapes
{
    public class RectangularParallelepiped : Figure
    {
        public Point _point { get; set; }

        public Point _point2 { get; set; }

        public RectangularParallelepiped()
        {
            _point = new Point();
            _point2 = new Point();
        }

        public RectangularParallelepiped(Point point, Point point2)
        {
            _point = point;
            _point2 = point2;
        }

        public double GetWidth()
        {
            return Math.Abs(_point._x - _point2._x);
        }

        public double GetLength()
        {
            return Math.Abs(_point._y - _point2._y);
        }

        public double GetHigth()
        {
            return Math.Abs(_point._z - _point2._z);
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(_point._x, _point._y,_point._z),
                new Point(_point2._x, _point2._y, _point2._z)
                );
        }

        public override double GetSurfaceArea()
        {
            return 2 * (GetHigth() * GetWidth() + GetWidth() * GetLength() + GetLength() * GetHigth());
        }

        public override double GetVolume()
        {
            return GetHigth() * GetWidth() * GetLength();
        }

        public override string ToString()
        {
            return "1: " + _point + "2: " + _point2;
        }

        public override bool Equals(Object obj) // исправить
        {
            try
            {
                RectangularParallelepiped rectangularCuboid = obj as RectangularParallelepiped;
                return rectangularCuboid._point.Equals(_point) &&
                rectangularCuboid._point2.Equals(_point2);
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public override int GetHashCode()
        {
            return _point.GetHashCode() ^ _point2.GetHashCode();
        }
    }
}

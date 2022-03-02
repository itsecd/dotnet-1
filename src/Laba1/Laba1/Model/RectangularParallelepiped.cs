using System;

namespace Laba1.Model
{
    public class RectangularParallelepiped : Figure3D
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        RectangularParallelepiped()
        {
            Point1 = new Point();
            Point2 = new Point();
        }
        public RectangularParallelepiped(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
        public RectangularParallelepiped(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Point1 = new Point(x1, y1, z1);
            Point2 = new Point(x2, y2, z2);
        }
        public double GetWidth()
        {
            return Math.Abs(Point1.X - Point2.X);
        }
        public double GetLength()
        {
            return Math.Abs(Point1.Y - Point2.Y);
        }
        public double GetHeight()
        {
            return Math.Abs(Point1.Z - Point2.Z);
        }
        public override double GetArea()
        {
            return 2 * (GetLength() * GetWidth() + GetLength() * GetHeight() + GetWidth() * GetHeight());
        }

        public override double GetVolume()
        {
            return GetLength() * GetWidth() * GetHeight();
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped(
                new(Point1.X, Point1.Y, Point1.Z), new(Point2.X, Point2.Y, Point2.Z));
        }
        public override string ToString()
        {
            return $"Point1: {Point1}\nPoint2: {Point2}\n";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            var parallelepiped = (RectangularParallelepiped)obj;
            if (Point1.Equals(parallelepiped.Point1) && Point2.Equals(parallelepiped.Point2))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Point1.GetHashCode() ^ Point2.GetHashCode();
        }
    }
}


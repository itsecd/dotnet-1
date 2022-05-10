using System;

namespace Lab1_3D.Model
{
    public class RectangularParallelepiped: Figure3D
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public RectangularParallelepiped()
        {
            Point1 = new Point();
            Point2 = new Point();
        }
        public RectangularParallelepiped(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Point1 = new Point(x1, y1, z1);
            Point2 = new Point(x2, y2, z2);
        }

        public RectangularParallelepiped(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public double A()
        {
            return Math.Abs(Point1.X - Point2.X);
        }
        public double B()
        {
            return Math.Abs(Point1.Y - Point2.Y);
        }
        public double H()
        {
            return Math.Abs(Point1.Z - Point2.Z);
        }

        public override double GetSurfaceArea()
        {
            return 2 * (A() * B() + A() * H() + B() * H());
        }

        public override double GetVolume()
        {
            return A() * B() * H();
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped(new(Point1.X, Point1.Y, Point1.Z), new(Point2.X, Point2.Y, Point2.Z));
        }

        public override string ToString()
        {
            return $"{Point1.X} {Point1.Y} {Point1.Z} {Point2.X} {Point2.Y} {Point2.Z}";
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            else
            {
                var parallelepiped = (RectangularParallelepiped)obj;
                return Point1.Equals(parallelepiped.Point1) && Point2.Equals(parallelepiped.Point2);
            }
        }

        public override int GetHashCode()
        {
            return Point1.X.GetHashCode() ^ Point1.Y.GetHashCode() ^ Point1.Z.GetHashCode() ^ Point2.X.GetHashCode() ^ Point2.Y.GetHashCode() ^ Point2.Z.GetHashCode();
        }
    }
}

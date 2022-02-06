using System;

namespace Lab1.Model
{
    internal struct Point
    {
        public double X;

        public double Y;

        public Point(double x, double y) { X = x; Y = y; }

        public double DistanceTo(Point point)
        {
            var xDiff = point.X - X;
            var yDiff = point.Y - Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
    }
}

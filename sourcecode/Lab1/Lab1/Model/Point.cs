using System;

namespace Lab1.Model
{
    public struct Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Distance(Point point)
        {
            var xDiff = point.X - X;
            var yDiff = point.Y - Y;
            var zDiff = point.Z - Z;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff + zDiff * zDiff);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Point vertex) return false;
            return X == vertex.X && Y == vertex.Y && Z == vertex.Z;
        }
    }
}

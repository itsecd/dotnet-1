using System;

namespace Lab1
{
    public struct Point
    {
        public double X { get; init; }
        public double Y { get; init; }

        public Point(double x, double y) { X = x; Y = y; }

        public double Distance(Point second)
        {
            return Math.Sqrt(Math.Pow((X - second.X), 2) + Math.Pow((Y - second.Y), 2));
        }

        public override string ToString() => "(" + X + ", " + Y + ")";

        public static bool operator !=(Point left, Point right)
        {
            return left.X != right.X ||
                left.Y != right.Y;
        }

        public static bool operator ==(Point right, Point left)
        {
            return left.X == right.X &&
                    left.Y == right.Y;
        }


        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}

using System;

namespace Lab1.Model
{
    public struct Point
    {
        public double X { get; init; }

        public double Y { get; init; }

        public Point(double x, double y) { X = x; Y = y; }

        public double Distance(Point point) => Math.Sqrt((point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y));

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Point point) return false;
            else return point.X == X && point.Y == Y;
        }

    }



}

using System;

namespace Lab1.Model
{
    public struct Point
    {
        public double X { get; init; }
        public double Y { get; init; }

        public Point(double x, double y) 
        {
            X = x; 
            Y = y; 
        }
        public double DistanceTo(Point point)
        {
            var xDiff = point.X - X;
            var yDiff = point.Y - Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
        public static bool operator ==(Point right, Point left)
        {
            return left.X == right.X && left.Y == right.Y;
        } 
        public static bool operator !=(Point right, Point left)
        {
            return left.X != right.X || left.Y != right.Y;
        }
        public override bool Equals(Object obj)
        {
            if(obj is Point point)
            {
                return X == point.X && Y == point.Y;
            }
            return false;
        }
    }
}
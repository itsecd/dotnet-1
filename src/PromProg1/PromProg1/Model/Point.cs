using System;
using System.Xml.Serialization;

namespace PromProg1
{
    [Serializable]
    [XmlRoot("Point")]
    public struct Point
    {
        [XmlElement("X")]
        public double X { get; init; }
        [XmlElement("Y")]
        public double Y { get; init; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double DistanceTo(Point second)
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


        public override bool Equals(object obj)
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

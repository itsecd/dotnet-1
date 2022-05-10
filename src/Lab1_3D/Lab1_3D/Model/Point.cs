using System;

namespace Lab1_3D.Model
{
    public struct Point
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public Point (double x, double y, double z) { X = x; Y = y; Z = z; }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Point point = (Point)obj;
                return X == point.X && Y == point.Y && Z == point.Z;
            }
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }
}

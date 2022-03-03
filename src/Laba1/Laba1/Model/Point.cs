
namespace Laba1.Model
{
    public struct Point
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var point = (Point)obj;
            return X == point.X && Y == point.Y && Z == point.Z;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }
}

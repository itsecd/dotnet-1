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
        public override string ToString() => $"({X},{Y})";
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var point = (Point)obj;
            return point.X == X && point.Y == Y;
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();
    }
}

namespace Lab1.Shapes
{
    public struct Point
    {
        public int X { get; init; }
        public int Y { get; init; }
        public int Z { get; init; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public  override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override string ToString()
        {
            return "x: " + X + " y: " + Y + " z: " + Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point point)
            {
                return X == point.X &&
                   Y == point.Y &&
                   Z == point.Z;
            }
            return false;
        }


    }
}


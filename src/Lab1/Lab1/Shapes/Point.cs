namespace Lab1.Shapes
{
    public struct Point
    {
        public int _x { get; set; }
        public int _y { get; set; }
        public int _z { get; set; }

        public Point(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
        }

        public override string ToString()
        {
            return "x: " + _x + " y: " + _y + " z: " + _z;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   _x == point._x &&
                   _y == point._y &&
                   _z == point._z;
        }


    }
}


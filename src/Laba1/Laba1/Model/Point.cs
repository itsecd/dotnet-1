
namespace Laba1.Model
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
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var point = (Point)obj;
            if (X == point.X && Y == point.Y && Z == point.Z)
            {
                return true;
            }
            return false;
        }
                

    }
}

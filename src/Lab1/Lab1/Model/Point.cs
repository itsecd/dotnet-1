using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var point = (Point)obj;
            if (X == point.X && Y == point.Y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();
    }
}

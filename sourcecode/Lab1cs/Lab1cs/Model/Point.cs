using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1cs.Model
{
    public struct Point
    {
        public double X;
        public double Y;
        public double Z;
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Distance(Point point)
        {
            var xDiff = point.X - X;
            var yDiff = point.Y - Y;
            var zDiff = point.Z - Z;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff + zDiff * zDiff);

        }
    }
}

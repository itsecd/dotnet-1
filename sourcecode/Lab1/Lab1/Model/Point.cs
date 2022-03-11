using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public struct Point
    {
        private double X;
        private double Y;
        private double Z;
        public double x
        {
            get => X;
            set { X = value; }
        }
        public double y
        {
            get => Y;
            set { Y = value; }
        }
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

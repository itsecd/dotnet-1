using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Mode
{
    public struct Point
    {
        public double X;
        public double Y;


        public Point(double x, double y) { X = x; Y = y; }

        public Point(Point A)
        {
            X = A.X;
            Y = A.Y;
        }

        public double Distance(Point A)
        {
            return Math.Sqrt((A.X - X) * (A.X - X) + (A.Y - Y) * (A.Y - Y));
        }


        public override string ToString()
        {
            return $"[{X},{Y}]";
        }

    }



}

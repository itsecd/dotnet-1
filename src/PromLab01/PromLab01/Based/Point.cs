using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    public struct Point
    {
        double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(double x)
        {
            this.x = x;
            y = 0;
        }
        new public string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        static public double GetLength(Point a, Point b)
        {
            var c = new Point();
            c.X = b.X - a.X;
            c.Y = b.Y - a.Y;
            return Math.Sqrt(Math.Pow(c.X,2) + Math.Pow(c.Y,2));
        }
        static public Point GetMiddle(Point a, Point b)
        {
            var c = new Point();
            c.X = (a.X + b.X) / 2;
            c.Y = (a.Y + b.Y) / 2;
            return c;
        }

    }
}

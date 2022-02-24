using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    internal struct Point
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
        public void Print()
        {
            Console.WriteLine($"({x};{y})");
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

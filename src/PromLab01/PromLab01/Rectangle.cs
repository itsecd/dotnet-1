using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    internal class Rectangle : ICalculations
    {
        Point a;
        public Point A
        {
            get { return a; }
            set { a = value; }
        }
        Point b;
        public Point B
        {
            get { return b; }
            set { b = value; }  
        }
        public Rectangle(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        public Rectangle(Point a, double width)
        {
            this.a = a;
            b = new Point (a.X + width, a.Y - width);

        }
        public Rectangle()
        {
            this.a = new Point(0);
            this.b = new Point(0);
        }

        public double GetArea()
        {
            return Math.Abs(b.X-a.X)*Math.Abs(b.Y-a.Y);
        }

        public double GetPerimeter()
        {
            return 2*Math.Abs(b.X - a.X) + 2* Math.Abs(b.Y - a.Y);
        }

        public Rectangle GetBorders()
        {
            return new Rectangle(a, b);
        }

        new public string ToString()
        {
            return "{" + a.ToString() + ";" + b.ToString() + "}";
        }
    }
}

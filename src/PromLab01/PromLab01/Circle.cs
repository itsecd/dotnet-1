using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    internal class Circle : ICalculations
    {
        Point a;
        public Point A 
        {
            get { return a; }
            set { a = value; }
        }

        double radius;
        public double Radius 
        { 
            get { return radius; }
            set { radius = value; } 
        }
        public Circle(Point a, double radius)
        {
            this.a = a;
            this.radius = radius;
        }
        public Circle(Point a, Point b)
        {
            this.a=a;
            radius = Point.GetLength(a, b)/2;
        }
        public Circle()
        {
            radius = 0;
            a = new Point(0);
        }
        public double GetArea()
        {
            return radius * radius * Math.PI;
        }

        public double GetPerimeter()
        {
            return 2*Math.PI * radius;
        }

        public Rectangle GetBorders()
        {
            return new Rectangle(A, Radius);
        }

        new public string ToString()
        {
            return "{" + A.ToString() + ";" + "R: " + Radius;
        }

    }
}

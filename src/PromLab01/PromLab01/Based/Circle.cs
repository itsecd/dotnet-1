using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    public class Circle : Figure, ICalculations
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
        public override double GetArea()
        {
            return radius * radius * Math.PI;
        }

        public override double GetPerimeter()
        {
            return 2*Math.PI * radius;
        }

        public override Rectangle GetBorders()
        {
            return new Rectangle(A, Radius);
        }

        public override string ToString()
        {
            return "{" + A.ToString() + ";" + "R: " + Radius;
        }

    }
}

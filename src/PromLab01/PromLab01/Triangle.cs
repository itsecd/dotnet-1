using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    internal class Triangle : ICalculations
    {
        Point[] array;
        public Point[] Array
        {
            get;
            set;
        }

        public Triangle(Point a, Point b, Point c)
        {
            Array = new Point[3] {a, b, c};
        }
        public Triangle()
        {
            Array = new Point[3] { new Point(0), new Point(0), new Point(0) };
        }

        public double GetArea()
        {
            return Math.Sqrt(GetPerimeter() 
                * (GetPerimeter() - Point.GetLength(Array[0], Array[1]))
                * (GetPerimeter() - Point.GetLength(Array[1], Array[2])) 
                * (GetPerimeter() - Point.GetLength(Array[2], Array[0])));
        }

        public double GetPerimeter()
        {
            return Point.GetLength(Array[0], Array[1]) 
                + Point.GetLength(Array[1], Array[2]) 
                + Point.GetLength(Array[2], Array[0]);
        }

        public Rectangle GetBorders()
        {
            return new Rectangle(new Point(Array.Min(array => array.X), Array.Min(array => array.Y)),
                new Point(Array.Max(array => array.X), Array.Max(array => array.Y)));
        }

        new public string ToString()
        {
            return "{" + Array[0].ToString() + ";" + Array[1].ToString()
                + ";" + Array[2].ToString() + "}";
        }
    }
}

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
        Point b;
        Point middle;
        double width;
        double height;

        public double Width
        {
            get { return width; }
        }
        public double Height
        {
            get { return height; }
        }

        public Rectangle(Point a, Point b)
        {
            this.a = a;
            this.b = b;
            middle = Point.GetMiddle(a, b);
            width = middle.X;
            height = middle.Y;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetPerimeter()
        {
            return 2*width + 2*height;
        }

        public Rectangle GetBorders() //заглушка
        {
            return new Rectangle(a, b);
        }

        new public void ToString()
        {
            Console.WriteLine($"Width: {Width}, Height: {Height}, Starting point: ({a.X};{a.Y})");
        }
    }
}

using System;

namespace PromLab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new Point();
            a.X = 1;
            a.Y = 1;
            Console.WriteLine(a.ToString());
            var b = new Point(5,3);
            Console.WriteLine(b.ToString());
            var c = Point.GetMiddle(a, b);
            Console.WriteLine(c.ToString());
            var d = new Rectangle(a, b);
            Console.WriteLine(d.ToString());
            Console.WriteLine($"Area: {d.GetArea()}, Perimeter: {d.GetPerimeter()}");
            var e = new Circle(a,c);
            Console.WriteLine(e.ToString());
            Console.WriteLine($"Area: {e.GetArea()}, Perimeter: {e.GetPerimeter()}");
            e = new Circle(a, Point.GetLength(c, b));
            Console.WriteLine(e.ToString());
            Console.WriteLine($"Area: {e.GetArea()}, Perimeter: {e.GetPerimeter()}");
            var s = e.GetBorders();
            Console.WriteLine(s.ToString());
            var z = new Triangle(a, b, c);
            Console.WriteLine(z.ToString());
            Console.WriteLine($"Area: {z.GetArea()}, Perimeter: {z.GetPerimeter()}");


        }
    }
}

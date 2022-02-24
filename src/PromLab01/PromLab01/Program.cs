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
            a.Print();
            var b = new Point(2,2);
            b.Print();
            var c = Point.GetMiddle(a, b);
            c.Print();
            var d = new Rectangle(a, b);
            d.ToString();
            Console.WriteLine($"Area: {d.GetArea()}, Perimeter: {d.GetPerimeter()}");

        }
    }
}

using System;
using System.Text;

namespace Lab1.Model
{
    internal class Rectangle : Figure
    {
        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public double A => Math.Abs(Point1.X - Point2.X);

        public double B => Math.Abs(Point1.Y - Point2.Y);

        public Rectangle()
        {
        }

        public Rectangle(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public override double GetLength()
        {
            return 2 * (A + B);
        }

        public override string ToString()
        {
            return $"{Point1.X} {Point1.Y} {Point2.X} {Point2.Y}";
        }
    }
}

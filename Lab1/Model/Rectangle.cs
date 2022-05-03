using System;

namespace Lab1.Model
{
    public class Rectangle: Figure
    {
        public Point Point1 { get; init; }
        public Point Point2 { get; init; }

        public Rectangle()
        {
            Point1 = new Point();
            Point2 = new Point();
        }
        public Rectangle(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
        public Rectangle (double x1, double y1, double x2, double y2)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
        }
        public double GetLength() => Math.Abs(Point1.X - Point2.X);
        public double GetWidth() => Math.Abs(Point1.Y - Point2.Y);
        public override double GetPerimeter() => 2 * (GetLength() + GetWidth());

        public override double GetArea() => GetLength() * GetWidth();

        public override Rectangle GetMinRectangle() => new Rectangle(new Point(Point1.X, Point1.Y), new Point(Point2.X, Point2.Y));

        public override string ToString() => $"Point1: {Point1}\nPoint2: {Point2}\n";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var rectangle = (Rectangle)obj;
            return Point1.Equals(rectangle.Point1) && Point2.Equals(rectangle.Point2);
        }

        public override int GetHashCode() => Point1.GetHashCode() ^ Point2.GetHashCode();
    }
}

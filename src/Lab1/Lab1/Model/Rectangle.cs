using System;

namespace Lab1.Model
{
    public class Rectangle: Figure
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

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
        public double GetLength()
        {
            return Math.Abs(Point1.X - Point2.X);
        }
        public double GetWidth()
        {
            return Math.Abs(Point1.Y - Point2.Y);
        }
        public override double GetPerimeter()
        {
            return 2 * (GetLength() + GetWidth());
        }

        public override double GetArea()
        {
            return GetLength() * GetWidth();
        }

        public override Rectangle GetMinRectangle()
        {
            return new Rectangle(new Point(Point1.X, Point1.Y), new Point(Point2.X, Point2.Y));
        }

        public override string ToString()
        {
            return $"Point1: {Point1}\nPoint2: {Point2}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var rectangle = (Rectangle)obj;
            if (Point1.Equals(rectangle.Point1) && Point2.Equals(rectangle.Point2))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

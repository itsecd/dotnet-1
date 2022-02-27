using System;
using System.Xml.Serialization;

namespace PromProg1
{
    [Serializable]
    [XmlRoot("Rectangle")]
    public class Rectangle:Figure
    {
        [XmlElement("FirstPoint")]
        public Point FirstPoint { get; init; }
        [XmlElement("LastPoint")]
        public Point LastPoint { get; init; }
        public Rectangle()
        {
            FirstPoint = new Point();
            LastPoint = new Point();
        }
        public Rectangle(Point first, Point last)
        {
            FirstPoint = first;
            LastPoint = last;
        }
        public double GetWidth()
        {
            return Math.Abs(FirstPoint.X - LastPoint.X);
        }
        public double GetLength()
        {
            return Math.Abs(FirstPoint.Y - LastPoint.Y);
        }
        public override Rectangle FramingRectangle() => new (FirstPoint, LastPoint);

        public override double Perimeter() => 2 * (GetWidth() + GetLength());

        public override double Square() => GetWidth() * GetLength();

        public override string ToString() => $"Rectangle: {FirstPoint},{LastPoint}; a = {GetWidth()}, b = {GetLength()}";

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point>(FirstPoint, LastPoint);
        }
        public override bool Equals(Object obj)
        {
            if (obj is Rectangle rectangle)
            {
                return rectangle.FirstPoint.Equals(FirstPoint) &&
                    rectangle.LastPoint.Equals(LastPoint);
            }
            return false;
        }

    }
}
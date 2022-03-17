using System;


namespace Lab1.Model
{
    public class Circle : Figure
    {
        public Point Center { get; init; }
        public double Radius { get; init; } = 1;

        public Circle() { }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override double GetPerimeter() => Math.PI * 2 * Radius;

        public override double GetArea() => Math.PI * Radius * Radius;

        public override Rectangle MinBoundingBox()
        {
            var minBoundingBox = new Rectangle(new Point(Center.X + Radius, Center.Y + Radius), new Point(Center.X - Radius, Center.Y - Radius));
            return minBoundingBox;
        }

        public override string ToString() => $"Circle: ({Center.ToString()}, {Radius})";

        public override bool Equals(object? obj)
        {
            if (obj is not Circle circle) return false;
            else return circle.Center.Equals(Center) && circle.Radius == Radius;
        }

    }
}

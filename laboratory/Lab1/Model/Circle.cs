using System;

namespace Lab1.Model
{
    public class Circle : Figure
    {
        public double Radius { get; init; }
        public Point Center { get; init; }

        public Circle()
        {

        }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override double Perimeter() => 2 * Math.PI * Radius;

        public override Rectangle FramingRectangle() => new(new Point(Center.X - Radius, Center.Y - Radius),
                                                            new Point(Center.X + Radius, Center.Y + Radius));

        public override double Area() => Math.PI * Math.Pow(Radius, 2);

        public override string ToString() => $"{Center}, {Radius}";

        public override bool Equals(object? obj)
        {
            if (obj is Circle circleObj)
                return Equals(circleObj);
            else
                return false;
        }

        public override bool Equals(Figure? obj)
        {
            if (obj is not Circle other)
                return false;
            return Radius == other.Radius &&
                   Center == other.Center;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Center, Radius);
        }
    }
}

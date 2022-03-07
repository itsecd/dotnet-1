using System;

namespace laboratory.model
{
    public class Circle : Figure
    {
        public double Radius { get; init; }
        public Point Center { get; init; }

        public Circle()
        {

        }

        public Circle(Point a, double r)
        {
            Center = a;
            Radius = r;
        }

        public override double Perimeter() => 2 * Math.PI * Radius;

        public override Rectangle FramingRectangle() => new(new Point(Center.X - Radius, Center.Y - Radius),
                                                            new Point(Center.X + Radius, Center.Y + Radius));

        public override double Square() => Math.PI * Math.Pow(Radius, 2);

        public override string ToString() => $"{Center}, {Radius}";

        public bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Rectangle personObj = obj as Rectangle;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override bool Equals(Figure obj)
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

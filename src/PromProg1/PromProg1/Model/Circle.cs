using System;

namespace PromProg1
{
    public class Circle: Figure
    {
        public double Radius { get; init; }
        public Point Centr { get; init; }
        public Circle()
        {
            Centr = new Point();
            Radius = 0;
        }
        public Circle(Point centr, double r)
        {
            Centr = centr;
            Radius = r;
        }
        public override double Perimeter() => 2 * Math.PI * Radius;

        public override Rectangle FramingRectangle() => new(new Point(Centr.X - Radius, Centr.Y - Radius),
                                                            new Point(Centr.X + Radius, Centr.Y + Radius));

        public override double Square() => Math.PI * Math.Pow(Radius, 2);

        public override string ToString() => $"Circle: Centr{Centr}, radius = {Radius}";
        public override int GetHashCode()
        {
            return HashCode.Combine(Centr, Radius);
        }
        public override bool Equals(Object obj)
        {
            if (obj is Circle circle)
            {
                return circle.Centr.Equals(Centr) &&
                    circle.Radius == Radius;
            }
            return false;
        }

    }
}
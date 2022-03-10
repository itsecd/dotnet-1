using System;

namespace Lab1.Model
{
    public class Circle : Figure
    {
        public Point Center { get;  }
        private double Radius { get;  }
        public Circle() { }

        public Circle(Point center, double r)
        {
            Center = center;
            Radius = r;
        }

        public override double Perimeter() => Math.PI * 2 * Radius;

        public override double Square() => Math.PI * Radius * Radius;

        public override Rectangle MinBoundingFigure()
        {
            var Result = new Rectangle(new Point(Center.x + Radius, Center.y + Radius), new Point(Center.x + Radius, Center.y - Radius), new Point(Center.x - Radius, Center.y - Radius), new Point(Center.x - Radius, Center.y + Radius));
            return Result;
        }

        public override string ToString() => $"Circle: ({Center.ToString()}, {Radius})";

        public override bool Equals(object? obj)
        {
            if (obj is Circle c) return c.Center.Equals(Center) && c.Radius == Radius;
            else return false;
        }

    }
}

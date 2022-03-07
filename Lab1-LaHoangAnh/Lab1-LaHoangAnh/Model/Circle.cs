using System;

namespace Lab1.Model
{
    public class Circle : Figure
    {
        public Point Center { get; init; }
        private double Radius { get; init; }
        public Circle() { }

        public Circle(Point center, double r)
        {
            Center = center;
            Radius = r;
        }

        public override double Perimeter()
        {
            return Math.PI * 2 * Radius;
        }

        public override double Square()
        {
            return Math.PI * Radius * Radius;
        }

        public override Rectangle MinBoundingFigure()
        {
            var Result = new Rectangle(new Point(Center.x + Radius, Center.y + Radius), new Point(Center.x + Radius, Center.y - Radius), new Point(Center.x - Radius, Center.y - Radius), new Point(Center.x - Radius, Center.y + Radius));
            return Result;
        }

        public override string ToString()
        {
            return $"Circle: ({Center.ToString()}, {Radius})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            if(obj == this) return true;
            var circle = (Circle)obj;
            return Center.Equals(circle.Center) && Radius == circle.Radius;
        }

    }
}

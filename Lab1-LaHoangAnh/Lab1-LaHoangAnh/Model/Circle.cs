using System;

namespace Lab1.Mode
{
    public class Circle : Figure
    {
        public Point Center { get; init; }
        private double Radius { get; init; }

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
            if (obj.GetType() == this.GetType())
            {
                if (obj.ToString() == this.ToString()) return true;
                else return false;
            }
            else return false;
        }

    }
}

using System;
using System.Linq;

namespace laboratory.model
{
    public class Triangle : Figure
    {

        public Point TopA { get; init; }
        public Point TopB { get; init; }
        public Point TopC { get; init; }

        public Triangle()
        {

        }

        public Triangle(Point a, Point b, Point c)
        {
            TopA = a;
            TopB = b;
            TopC = c;
        }

        private double A => TopA.Distance(TopA);
        private double B => TopA.Distance(TopC);
        private double C => TopC.Distance(TopB);

        public override Rectangle FramingRectangle()
        {
            double max_x = TopA.X, max_y = TopA.Y,
                min_x = TopC.X, min_y = TopC.Y;
            if (max_x < TopB.X || max_x < TopC.X)
                if (TopC.X < TopB.X) max_x = TopB.X; else max_x = TopC.X;
            if (max_y < TopB.Y || max_y < TopC.Y)
                if (TopC.Y < TopB.Y) max_y = TopB.Y; else max_y = TopC.Y;
            if (min_x > TopB.X || min_x > TopA.X)
                if (TopA.X > TopB.X) min_x = TopB.X; else min_x = TopA.X;
            if (min_y > TopB.X || min_y > TopA.X)
                if (TopA.X > TopB.X) min_y = TopB.X; else min_y = TopA.X;
            return new(new Point(min_x,min_y), new Point(max_x, max_y)); 
        }

        public override double Perimeter() => A + B + C;

        public override double Square()
        {
            var per = Perimeter() / 2;
            return Math.Sqrt(per * (per - A) * (per - B) * (per - C));
        }

        public override string ToString() => $"{A}, {B}, {C}";

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
            if (obj is not Triangle other)
                return false;
            return A == other.A &&
                B == other.B &&
                C == other.C;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point, Point>(TopA, TopB, TopC);
        }
    }
}

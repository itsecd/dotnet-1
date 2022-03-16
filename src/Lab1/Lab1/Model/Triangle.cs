using System;
using System.Linq;

namespace Lab1.Model
{
    public class Triangle : Figure
    {
        public Point[] Points { get; init; }

        private double A => Points[0].DistanceTo(Points[1]);

        private double B => Points[1].DistanceTo(Points[2]);

        private double C => Points[2].DistanceTo(Points[0]);

        public Triangle()
        {
            Points = Array.Empty<Point>();
        }

        public Triangle(Point point1, Point point2, Point point3)
        {
            Points = new Point[] { point1, point2, point3 };
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }

        public override double GetArea()
        {
            var halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
        }

        public override Rectangle GetMinFramingRectangle()
        {
            return new Rectangle(new Point(Points.Min(points => points.X), Points.Min(points => points.Y)),
                new Point(Points.Max(points => points.X), Points.Max(points => points.Y)));
        }

        public override string ToString()
        {
            return $"({Points[0].X};{Points[0].Y}), " +
                $"({Points[1].X};{Points[1].Y}), ({Points[2].X};{Points[2].Y})";
        }

        public override bool Equals(Object obj)
        {
            if(obj is Triangle triangle)
            {
                return triangle.Points[0] == Points[0] && triangle.Points[1] == Points[1]
                    && triangle.Points[2] == Points[2];
            }
            return false;
        }
    }
}
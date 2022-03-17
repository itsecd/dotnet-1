using System;

namespace Lab1.Model
{
    public class Triangle : Figure
    {
        public Point Vertex1 { get; init; }
        public Point Vertex2 { get; init; }
        public Point Vertex3 { get; init; }

        public Triangle()
        {
            Vertex1 = new Point();
            Vertex2 = new Point();
            Vertex3 = new Point();
        }

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

        public override double GetPerimeter() => Vertex1.Distance(Vertex2) + Vertex2.Distance(Vertex3) + Vertex3.Distance(Vertex1);

        public override double GetArea() => Math.Sqrt(GetPerimeter() / 2 * (GetPerimeter() / 2 - Vertex1.Distance(Vertex2)) * (GetPerimeter() / 2 - Vertex2.Distance(Vertex3)) * (GetPerimeter() / 2 - Vertex3.Distance(Vertex1)));

        public override Rectangle MinBoundingBox() => new Rectangle(new Point(Math.Min(Vertex1.X, Math.Min(Vertex2.X, Vertex3.X)), Math.Min(Vertex1.Y, Math.Min(Vertex2.Y, Vertex3.Y))), new Point(Math.Max(Vertex1.X, Math.Max(Vertex2.X, Vertex3.X)), Math.Max(Vertex1.Y, Math.Max(Vertex2.Y, Vertex3.Y))));

        public override string ToString() => $"Tritangle: ({Vertex1.ToString()}, {Vertex2.ToString()}, {Vertex3.ToString()})";

        public override bool Equals(object? obj)
        {
            if (obj is not Triangle triangle) return false;
            else return triangle.Vertex1.Equals(Vertex1) && triangle.Vertex2.Equals(Vertex2) && triangle.Vertex3.Equals(Vertex3);
        }
    }
}

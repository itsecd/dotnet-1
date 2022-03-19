using System;

namespace Lab1.Model
{
    public class Rectangle : Figure
    {

        public Point VertexA { get; init; }

        public Point VertexB { get; init; }

        public Rectangle()
        { }

        public Rectangle(Point vertexA, Point vertexB)
        {
            VertexA = vertexA;
            VertexB = vertexB;
        }

        private double Width => Math.Abs(VertexA.X - VertexB.X);

        private double Height => Math.Abs(VertexA.Y - VertexB.Y);

        public override Rectangle FramingRectangle() => new Rectangle(VertexA, VertexB);

        public override double Perimeter() => 2 * (Width + Height);

        public override double Area() => Width * Height;

        public override string ToString() => $"{VertexA}&{VertexB};{Width}, {Height}";

        public override bool Equals(object? obj)
        {
            if (obj is Rectangle rectangleObj)
                return Equals(rectangleObj);
            else
                return false;
        }

        public override bool Equals(Figure? obj)
        {
            if (obj is not Rectangle other)
                return false;
            return Width == other.Width &&
                    Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point>(VertexA, VertexB);
        }
    }
}

using Lab1.Model;
using System;

namespace Lab1.Shapes
{
    public class RectangularParallelepiped : Figure
    {
        public Point Vertex{ get; init; }

        public Point SecondVertex { get; init; }

        public RectangularParallelepiped()
        {
            Vertex = new Point();
            SecondVertex = new Point();
        }

        public RectangularParallelepiped(Point vertex, Point secondVertex)
        {
            Vertex = vertex;
            SecondVertex = secondVertex;
        }

        public double GetWidth()
        {
            return Math.Abs(Vertex.X - SecondVertex.X);
        }

        public double GetLength()
        {
            return Math.Abs(Vertex.Y - SecondVertex.Y);
        }

        public double GetHeigth()
        {
            return Math.Abs(Vertex.Z - SecondVertex.Z);
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(Vertex.X, Vertex.Y,Vertex.Z),
                new Point(SecondVertex.X, SecondVertex.Y, SecondVertex.Z)
                );
        }

        public override double GetSurfaceArea()
        {
            return 2 * (GetHeigth() * GetWidth() + GetWidth() * GetLength() + GetLength() * GetHeigth());
        }

        public override double GetVolume()
        {
            return GetHeigth() * GetWidth() * GetLength();
        }

        public override string ToString()
        {
            return "1: " + Vertex + "2: " + SecondVertex;
        }

        public override bool Equals(Object obj)
        {
            if (obj is RectangularParallelepiped rectangularParallelepiped)
            {
                return rectangularParallelepiped.Vertex.Equals(Vertex) &&
                    rectangularParallelepiped.SecondVertex.Equals(SecondVertex);
            }
            return false;
        }

        public  override int GetHashCode()
        {
            return Vertex.GetHashCode() ^ SecondVertex.GetHashCode();
        }
    }
}

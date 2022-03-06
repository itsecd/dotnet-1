using System;
using System.Linq;
using System.Xml.Serialization;

namespace PromProg1
{

    [Serializable]
    [XmlRoot("Triangle")]
    public class Triangle: Figure
    {
        [XmlElement("Vertex")]
        public Point[] Vertex { get; init; }
        public Triangle()
        {
            Vertex = Array.Empty<Point>();
        }

        public Triangle(Point a, Point b, Point c)
        {
            Vertex = new Point[] { a, b, c };
        }
        private double A => Vertex[0].DistanceTo(Vertex[1]);
        private double B => Vertex[0].DistanceTo(Vertex[2]);
        private double C => Vertex[2].DistanceTo(Vertex[1]);

        public override Rectangle FramingRectangle() => new(new Point(Vertex.Min(arrVertexes => arrVertexes.X),
                Vertex.Min(arrVertexes => arrVertexes.Y)),
            new Point(Vertex.Max(arrVertexes => arrVertexes.X),
                Vertex.Max(arrVertexes => arrVertexes.Y)));

        public override double Perimeter() => A + B + C;

        public override double Square()
        {
            var p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override string ToString() => $"Triangle: A:{A}, B:{B}, C:{C}";
        public override bool Equals(Object obj)
        {
            if (obj is Triangle triangle)
            {
                return triangle.A.Equals(A) &&
                    triangle.B.Equals(B) &&
                     triangle.C.Equals(C);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point, Point>(Vertex[0], Vertex[1], Vertex[2]);
        }

    }
}
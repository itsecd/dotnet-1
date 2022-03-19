using System;

namespace Lab1.Model
{
    public class Triangle : Figure
    {

        public Point VertexA { get; init; }
        public Point VertexB { get; init; }
        public Point VertexC { get; init; }

        public Triangle()
        {

        }

        public Triangle(Point vertexA, Point vertexB, Point vertexC)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            VertexC = vertexC;
        }

        private double SideAB => VertexA.Distance(VertexB);

        private double SideAC => VertexA.Distance(VertexC);

        private double SideCB => VertexC.Distance(VertexB);

        public override Rectangle FramingRectangle()
        {
            double max_x = VertexA.X, max_y = VertexA.Y,
                min_x = VertexC.X, min_y = VertexC.Y;
            if (max_x < VertexB.X || max_x < VertexC.X)
                if (VertexC.X < VertexB.X) max_x = VertexB.X; else max_x = VertexC.X;
            if (max_y < VertexB.Y || max_y < VertexC.Y)
                if (VertexC.Y < VertexB.Y) max_y = VertexB.Y; else max_y = VertexC.Y;
            if (min_x > VertexB.X || min_x > VertexA.X)
                if (VertexA.X > VertexB.X) min_x = VertexB.X; else min_x = VertexA.X;
            if (min_y > VertexB.X || min_y > VertexA.X)
                if (VertexA.X > VertexB.X) min_y = VertexB.X; else min_y = VertexA.X;
            return new(new Point(min_x, min_y), new Point(max_x, max_y));
        }

        public override double Perimeter() => SideAB + SideAC + SideCB;

        public override double Area()
        {
            var per = Perimeter() / 2;
            return Math.Sqrt(per * (per - SideAB) * (per - SideAC) * (per - SideCB));
        }

        public override string ToString() => $"{SideAB}, {SideAC}, {SideCB}";

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Rectangle? personObj = obj as Rectangle;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override bool Equals(Figure? obj)
        {
            if (obj is not Triangle other)
                return false;
            return SideAB == other.SideAB &&
                SideAC == other.SideAC &&
                SideCB == other.SideCB;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point, Point>(VertexA, VertexB, VertexC);
        }
    }
}

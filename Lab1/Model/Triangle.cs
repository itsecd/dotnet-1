using System;

namespace Lab1.Model
{
    public class Triangle: Figure
    {
        public Point A { get; init; }
        public Point B { get; init; }
        public Point C { get; init; }

        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
        }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            A = new Point(x1, y1);
            B = new Point(x2, y2);
            C = new Point(x3, y3);
        }
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
        public double AB() => Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
        public double BC() => Math.Sqrt(Math.Pow((C.X - B.X), 2) + Math.Pow((C.Y - B.Y), 2));
        public double AC() => Math.Sqrt(Math.Pow((A.X - C.X), 2) + Math.Pow((A.Y - C.Y), 2));
        public override double GetPerimeter() => AC() + BC() + AB();

        public override double GetArea()
        {
            var p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - AB()) * (p - AC()) * (p - BC()));
        }

        public override Rectangle GetMinRectangle() => new Rectangle
                (new Point(Math.Min(A.X, Math.Min(B.X, C.X)), Math.Min(A.Y, Math.Min(B.Y, C.Y))),
                new Point(Math.Max(A.X, Math.Max(B.X, C.X)), Math.Max(A.Y, Math.Max(B.Y, C.Y))));

        public override string ToString() => $"Point1: {A}\nPoint2: {B}\nPoint3: {C}\n";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var triangle = (Triangle)obj;
            return A.Equals(triangle.A) && B.Equals(triangle.B) && C.Equals(triangle.C);
        }

        public override int GetHashCode() => A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();
    }
}

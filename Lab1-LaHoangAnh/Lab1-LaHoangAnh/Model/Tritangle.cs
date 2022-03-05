using System;

namespace Lab1.Mode
{
    public class Tritangle : Figure
    {
        public Point A { get; init; }
        public Point B { get; init; }
        public Point C { get; init; }

        public Tritangle()
        {
            A = new Point(0, 0);
            B = new Point(0, 1);
            C = new Point(1, 0);
        }

        public Tritangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Perimeter()
        {
            return A.Distance(B) + B.Distance(C) + C.Distance(A);
        }

        public override double Square()
        {
           
            return Math.Sqrt(Perimeter() / 2 * (Perimeter() / 2 - A.Distance(B)) * (Perimeter() / 2 - B.Distance(C)) * (Perimeter() / 2 - C.Distance(A)));
        }

        public override Rectangle MinBoundingFigure()
        {
            double t1 = ((B.x - A.x) * (B.x - C.x) + (B.y - A.y) * (B.y - C.y)) / ((B.x - C.x) * (B.x - C.x) + (B.y - C.y) * (B.y - C.y));
            double t2 = ((C.x - A.x) * (B.x - C.x) + (C.y - A.y) * (B.y - C.y)) / ((B.x - C.x) * (B.x - C.x) + (B.y - C.y) * (B.y - C.y));
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Point Point1 = new Point(A.x + (B.x - C.x) * t1, A.y + (B.y - C.y) * t1);
            Point Point2 = new Point(A.x + (B.x - C.x) * t2, A.y + (B.y - C.y) * t2);
            var Result = new Rectangle(B, C, Point2, Point1);

            return Result;
        }
        public override string ToString()
        {
            
            return $"Tritangle: ({A.ToString()}, {B.ToString()}, {C.ToString()})";
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



namespace Lab1.Model
{
    public class Rectangle : Figure
    {
        public Point A { get;  }
        public Point B { get;  }
        public Point C { get;  }
        public Point D { get;  }


        public Rectangle()
        {
            A = new Point(0, 0);
            B = new Point(0, 1);
            C = new Point(1, 1);
            D = new Point(1, 0);
        }
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double Perimeter() => A.Distance(B) + B.Distance(C) + C.Distance(D) + D.Distance(A);

        public override double Square() => A.Distance(B) * B.Distance(C);

        public override Rectangle MinBoundingFigure() => this;

        public override string ToString() => $"Rectangle: ({A.ToString()},{B.ToString()},{C.ToString()},{D.ToString()})";

        public override bool Equals(object? obj)
        {
            if (obj is Rectangle rectangle) return rectangle.A.Equals(A) && rectangle.B.Equals(B) && rectangle.C.Equals(C) && rectangle.D.Equals(D);
            else return false;
        }
    }
}

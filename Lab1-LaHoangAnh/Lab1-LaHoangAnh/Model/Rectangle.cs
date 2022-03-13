namespace Lab1.Model
{
    public class Rectangle : Figure
    {
        private Point _A;
        public Point A {
            get => _A;
            set { _A = value; }
        }
        private Point _B;
        public Point B {
            get => _B;
            set { _B = value; }
        }
        private Point _C;
        public Point C {
            get => _C;
            set { _C = value; }
        }
        private Point _D;
        public Point D {
            get => _D;
            set { _D = value; }
        }

        public Rectangle()
        {
            _A = new Point(0, 0);
            _B = new Point(0, 1);
            _C = new Point(1, 1);
            _D = new Point(1, 0);
        }
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            _A = a;
            _B = b;
            _C = c;
            _D = d;
        }

        public override double Perimeter() => 2 * (_A.Distance(_B) + _B.Distance(_C));

        public override double Square() => _A.Distance(_B) * _B.Distance(_C);

        public override Rectangle MinBoundingBox() => this;

        public override string ToString() => $"Rectangle: ({_A.ToString()},{_B.ToString()},{_C.ToString()},{_D.ToString()})";

        public override bool Equals(object? obj)
        {
            if (obj is not Rectangle rectangle) return false;
            else return rectangle._A.Equals(_A) && rectangle._B.Equals(_B) && rectangle._C.Equals(_C) && rectangle._D.Equals(_D);
        }
    }
}

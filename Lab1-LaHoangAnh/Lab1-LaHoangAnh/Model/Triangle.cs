using System;

namespace Lab1.Model
{
    public class Triangle : Figure
    {
        private Point _A;
        public Point A {
            get => _A;
            set { _A = value; }
        }

        private Point _B;
        public Point B
        {
            get => _B;
            set { _B = value; }
        }

        private Point _C;
        public Point C
        {
            get => _C;
            set { _C = value; }
        }


        public Triangle()
        {
            _A = new Point(0, 0);
            _B = new Point(0, 1);
            _C = new Point(1, 0);
        }

        public Triangle(Point a, Point b, Point c)
        {
            _A = a;
            _B = b;
            _C = c;
        }

        public override double Perimeter() => _A.Distance(_B) + _B.Distance(_C) + _C.Distance(_A);

        public override double Square() => Math.Sqrt(Perimeter() / 2 * (Perimeter() / 2 - _A.Distance(_B)) * (Perimeter() / 2 - _B.Distance(_C)) * (Perimeter() / 2 - _C.Distance(_A)));

        public override Rectangle MinBoundingBox()
        {
            double K1 = ((_B.X - _A.X) * (_B.X - _C.X) + (_B.Y - _A.Y) * (_B.Y - _C.Y)) / ((_B.X - _C.X) * (_B.X - _C.X) + (_B.Y - _C.Y) * (_B.Y - _C.Y));
            double K2 = ((_C.X - _A.X) * (_B.X - _C.X) + (_C.Y - _A.Y) * (_B.Y - _C.Y)) / ((_B.X - _C.X) * (_B.X - _C.X) + (_B.Y - _C.Y) * (_B.Y - _C.Y));
            Point Point1 = new Point(_A.X + (_B.X - _C.X) * K1, _A.Y + (_B.Y - _C.Y) * K1);
            Point Point2 = new Point(_A.X + (_B.X - _C.X) * K2, _A.Y + (_B.Y - _C.Y) * K2);
            var minBoundingBox = new Rectangle(_B, _C, Point2, Point1);
            return minBoundingBox;
        }
        public override string ToString() => $"Tritangle: ({_A.ToString()}, {_B.ToString()}, {_C.ToString()})";

        public override bool Equals(object? obj)
        {
            if (obj is not Triangle triangle) return false;
            else return triangle._A.Equals(_A) && triangle._B.Equals(_B) && triangle._C.Equals(_C);
        }
    }
}

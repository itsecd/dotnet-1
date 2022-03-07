using System;

namespace laboratory.model
{
    public class Rectangle : Figure
    {

        public Point A { get; init; }

        public Point B { get; init; }

        public Rectangle()
        { }

        public Rectangle(Point point1, Point point2)
        {
            A = point1;
            B = point2;
        }

        private double Long => Math.Abs(A.X - B.X);
        private double Width => Math.Abs(A.Y - B.Y);

        public override Rectangle FramingRectangle() => new Rectangle(A, B);

        public override double Perimeter() => 2 * (Long + Width);

        public override double Square() => Long * Width;

        public override string ToString() => $"{A}&{B};{Long}, {Width}";

        public bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Rectangle personObj = obj as Rectangle;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }
        public override bool Equals(Figure obj)
        {
            if (obj is not Rectangle other)
                return false;
            return Long == other.Long &&
                    Width == other.Width;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine<Point, Point>(A, B);
        }        
    }
}

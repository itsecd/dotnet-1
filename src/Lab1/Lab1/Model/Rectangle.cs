using System;

namespace Lab1.Model
{
    public class Rectangle : Figure
    {
        public Point FirstPoint { get; init; }

        public Point SecondPoint { get; init; }

        private double A => Math.Abs(FirstPoint.X - SecondPoint.X);

        private double B => Math.Abs(FirstPoint.Y - SecondPoint.Y);

        public Rectangle()
        {
            FirstPoint = new Point(0, 0);
            SecondPoint = new Point(0, 0);
        }

        public Rectangle(Point point1, Point point2)
        {
            FirstPoint = point1;
            SecondPoint = point2;
        }

        public override double GetPerimeter()
        {
            return (_a + _b) * 2;
        }

        public override double GetArea()
        {
            return _a * _b;
        }

        public override Rectangle GetMinFramingRectangle()
        {
            return new Rectangle(FirstPoint, SecondPoint);
        }

        public override string ToString()
        {
            return $"({FirstPoint.X};{FirstPoint.Y}), ({SecondPoint.X};{SecondPoint.Y})";
        }

        public override bool Equals(Object obj)
        {
            if (obj is Rectangle rectangle)
            {
                return rectangle.FirstPoint == FirstPoint && rectangle.SecondPoint == SecondPoint;
            }
            return false;
        }
    }
}

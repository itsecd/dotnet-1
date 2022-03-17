using System;

namespace Lab1.Model
{
    public class Rectangle : Figure
    {
        public Point TopLeft { get; init; }

        public Point BottomRight { get; init; }

        public Rectangle()
        {
            TopLeft = new Point();
            BottomRight = new Point();
        }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public override double GetPerimeter() => 2 * (Math.Abs(TopLeft.X - BottomRight.X) + Math.Abs(TopLeft.Y - BottomRight.Y));

        public override double GetArea() => Math.Abs(TopLeft.X - BottomRight.X) * Math.Abs(TopLeft.Y - BottomRight.Y);

        public override Rectangle MinBoundingBox() => this;

        public override string ToString() => $"Rectangle: ({TopLeft.ToString()},{BottomRight.ToString()})";

        public override bool Equals(object? obj)
        {
            if (obj is not Rectangle rectangle) return false;
            else return rectangle.BottomRight.Equals(BottomRight) && rectangle.TopLeft.Equals(TopLeft);
        }
    }
}

using System;

namespace Lab1.Model
{
    public class Rectangle: Shape
    {
        public Point[] Points { get; set; }

        private double _A => Math.Abs(Points[0].X - Points[1].X);

        private double _B => Math.Abs(Points[0].Y - Points[1].Y);

        public Rectangle()
        {
            Points = Array.Empty<Point>();
        }

        public Rectangle(Point point1, Point point2)
        {
            Points = new Point[] { point1, point2 };
        }

        public override double GetPerimeter()
        {
            return _A + _B;
        }

        public override double GetArea()
        {
            return (_A + _B) * 2;
        }

        public override Rectangle GetMinFramingRectangle()
        {
            return new Rectangle(Points[0], Points[1]);
        }

        public override string ToString()
        {
            return $"Rectangle: ({Points[0].X};{Points[0].Y}), " +
                $"({Points[1].X};{Points[1].Y})";
        }

        public override bool Equals(Object obj)
        {
            if (obj is Rectangle rectangle)
            {
                return rectangle.Points[0] == Points[0] && rectangle.Points[1] == Points[1];
            }
            return false;
        }
    }
}

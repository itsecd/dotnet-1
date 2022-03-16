using System;

namespace Lab1.Model
{
    public class Circle : Figure
    {
        public Point Centre { get; init; }
        public double Radius { get; init; }
        public Circle()
        {
            Centre = new Point();
            Radius = 0;
        }
        public Circle(Point point, double radius)
        {
            Centre = point;
            Radius = radius;
        }

        public Circle(double x, double y, double radius)
        {
            Centre = new Point(x,y);
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);

        public override Rectangle GetMinRectangle() => new Rectangle
                (new Point(Centre.X - Radius, Centre.Y + Radius),
                new Point(Centre.X + Radius, Centre.Y - Radius));

        public override double GetPerimeter() => 2 * Math.PI * Radius;

        public override string ToString() => $"Centre: {Centre}\nRadius: {Radius}\n";
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var circle = (Circle)obj;
            return Centre.Equals(circle.Centre) && Radius == circle.Radius;
           
        }
        public override int GetHashCode() => Centre.GetHashCode() ^ Radius.GetHashCode();
    }
}

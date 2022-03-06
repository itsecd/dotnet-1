using System;

namespace Lab1.Model
{
    public class Circle: Shape
    {
        public Point Centre { get; set; }

        public double Radius { get; set; }

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

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override Rectangle GetMinFramingRectangle()
        {
            return new Rectangle(new Point(Centre.X - Radius, Centre.Y - Radius),
                new Point(Centre.X + Radius, Centre.Y + Radius));
        }

        public override string ToString()
        {
            return $"Circle: ({Centre.X}; {Centre.Y}) Radius = {Radius}";
        }

        public override bool Equals(Object obj)
        {
            if(obj is Circle circle)
            {
                return circle.Centre == Centre && circle.Radius == Radius;
            }
            return false;
        }
    }
}

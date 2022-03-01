using System;

namespace Lab1.Model
{
    public class Circle : Figure
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
       
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override Rectangle GetMinRectangle()
        {
            return new Rectangle
                (new Point(Centre.X-Radius,Centre.Y+Radius), 
                new Point(Centre.X + Radius, Centre.Y - Radius));
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Centre: {Centre}\nRadius: {Radius}\n";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var circle = (Circle)obj;
            if (Centre.Equals(circle.Centre) && Radius == circle.Radius)
            {
                return true;
            }
            return false;
        }
    }
}

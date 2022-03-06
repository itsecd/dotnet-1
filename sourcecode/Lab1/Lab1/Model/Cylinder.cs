using System;

namespace Lab1.Model
{
    public class Cylinder : Figure
    {
        public Point point { get; set; }
        public double pi = 3.14;
        public double radius;
        public Cylinder()
        {
            point = new Point(0, 0, 0);
            radius = 0;
            height = 0;
        }
        public Cylinder(Point point1, double r, double h)
        {
            point = point1;
            radius = r;
            height = h;
        }

        public Cylinder(double x, double y, double z, double r, double h)
        {
            point = new Point(x, y, z);
            radius = r;
            height = h;
        }

        public override double acreage()
        {
            return 2 * pi * radius * radius + 2 * pi * radius * height;
        }

        public override double volume()
        {
            return pi * radius * radius * height;
        }
        public override string ToString()
        {
            return "(" + point.X + "," + point.Y + "," + point.Z + ")" + " " + "Radius: " + radius + " " + "Height: " + height;
        }
        public override bool Equals(object obj)
        {
            if(obj == null|| GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Cylinder c = (Cylinder)obj;
                return point.Equals(c.point) && radius == c.radius && height == c.height;
            }
        }
    }
}

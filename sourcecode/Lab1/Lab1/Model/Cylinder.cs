using System;

namespace Lab1.Model
{
    public class Cylinder : Figure
    {
        public Point center { get; set; }
        public readonly double pi = Math.PI;
        private double radius;
        private double height;
        public double RadiusCylinder
        {
            get => radius;
            set { radius = value;}
        }
        public double HeightCylinder
        {
            get => height;
            set { height = value; }
        }
        public Cylinder()
        {
        }
        public Cylinder(Point Center, double r, double h)
        {
            center = Center;
            radius = r;
            height = h;
        }

        public override double SurfaceArea()
        {
            return 2 * pi * radius * radius + 2 * pi * radius * height;
        }

        public override double volume()
        {
            return pi * radius * radius * height;
        }
        public override string ToString()
        {
            return "(" + point.x + "," + point.y + "," + point.z + ")" + " " + "Radius: " + radius + " " + "Height: " + height;
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
                return center.Equals(c.center) && radius == c.radius && height == c.height;
            }
        }
    }
}

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

        public override bool Equals(object? obj)
        {
            if (obj is not Cylinder cylinder) return false;
            return center.Equals(cylinder.center) && radius == cylinder.radius && height == cylinder.height;
        }

        public Rectangular MinRectangular()
        {
            var rectangular = new Rectangular();
            var vertex1 = rectangular.Vertex1;
            var vertex2 = rectangular.Vertex2;
            vertex1.x = center.x - radius;
            vertex1.y = center.y - radius;
            vertex1.z = center.z;
            vertex2.x = center.x + radius;
            vertex2.y = center.y + radius;
            vertex2.z = center.z;
            rectangular.Height = height;
            return rectangular;
        }
    }
}

using System;

namespace Lab1.Model
{
    public class Sphere : Figure
    {
        public Point Center { get; set; }

        public double Radius { get; init; } = 1;

        public Sphere()
        {

        }

        public Sphere(Point center, double r)
        {
            Center = center;
            Radius = r;
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * Radius * Radius;
        }

        public override double GetVolume()
        {
            return 4 / 3 * Math.PI * Radius * Radius * Radius;
        }

        public override string ToString()
        {
            return "(" + Center.X + "," + Center.Y + "," + Center.Z + ")" + " " + "Radius: " + Radius;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Sphere sphere) return false;
            return Center.Equals(sphere.Center) && Radius == sphere.Radius;
        }

        public Rectangular MinRectangular()
        {
            var rectangular = new Rectangular();
            var vertex1 = rectangular.BaseLeftTop;
            var vertex2 = rectangular.BaseRightBottom;
            vertex1.X = Center.X - Radius;
            vertex1.Y = Center.Y - Radius;
            vertex1.Z = Center.Z - Radius;
            vertex2.X = Center.X + Radius;
            vertex2.Y = Center.Y + Radius;
            vertex2.Z = Center.Z - Radius;
            rectangular.Depth = 2 * Radius;
            return rectangular;
        }
    }
}

using System;

namespace Lab1.Model
{
    public class Sphere : Figure
    {
        public Point Center { get; init; }

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
            return ((4 * Math.PI * Radius * Radius * Radius) / 3);
        }

        public override string ToString()
        {
            return "(" + Center.X + "," + Center.Y + "," + Center.Z + ")" + " " + "Radius: " + Radius;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Sphere sphere) return false;
            return Center == sphere.Center && Radius == sphere.Radius;
        }

        public override Rectangular GetBoundingBox()
        {
            var minBoundingBox = new Rectangular(new Point(Center.X - Radius, Center.Y + Radius, Center.Z - Radius),
                new Point(Center.X + Radius, Center.Y - Radius, Center.Z - Radius), 2 * Radius);
            return minBoundingBox;
        }
    }
}

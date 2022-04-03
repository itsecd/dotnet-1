using System;

namespace Lab1.Model
{
    public class Cylinder : Figure
    {
        public Point Center { get; init; }

        public double Radius { get; init; } = 1;

        public double Height { get; init; } = 1;

        public Cylinder()
        {

        }

        public Cylinder(Point center, double radius, double height)
        {
            Center = center;
            Radius = radius;
            Height = height;
        }

        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * Radius + 2 * Math.PI * Radius * Height;
        }

        public override double GetVolume()
        {
            return Math.PI * Radius * Radius * Height;
        }

        public override string ToString()
        {
            return "(" + Center.X + "," + Center.Y + "," + Center.Z + ")" + " " + "Radius: " + Radius + " " + "Height: " + Height;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Cylinder cylinder) return false;
            return Center.Equals(cylinder.Center) && Radius == cylinder.Radius && Height == cylinder.Height;
        }

        public override Rectangular GetBoundingBox()
        {
            var minBoundingBox = new Rectangular(new Point(Center.X - Radius, Center.Y + Radius, Center.Z),
            new Point(Center.X + Radius, Center.Y - Radius, Center.Z), Height);
            return minBoundingBox;
        }
    }
}

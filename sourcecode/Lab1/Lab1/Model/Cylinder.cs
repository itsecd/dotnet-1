using System;

namespace Lab1.Model
{
    public class Cylinder : Figure
    {
        public Point Center { get; set; }

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

        public Rectangular MinRectangular()
        {
            var rectangular = new Rectangular();
            var vertex1 = rectangular.BaseLeftTop;
            var vertex2 = rectangular.BaseRightBottom;
            vertex1.X = Center.X - Radius;
            vertex1.Y = Center.Y - Radius;
            vertex1.Z = Center.Z;
            vertex2.X = Center.X + Radius;
            vertex2.Y = Center.Y + Radius;
            vertex2.Z = Center.Z;
            rectangular.Depth = Height;
            return rectangular;
        }
    }
}

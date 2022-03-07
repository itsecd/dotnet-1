using Lab1.Model;
using System;

namespace Lab1.Shapes
{
    public class Cylinder : Figure
    {

        public Point Centre { get; init; }

        public int Radius { get; init; }

        public int Height { get; init; }

        public Cylinder()
        {
            Radius = 0;
            Height = 0;
            Centre = new Point();
        }

        public Cylinder(Point centre, int radius, int height)
        {
            Centre = centre;
            Radius = radius;
            Height = height;
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(Centre.X + Radius, Centre.Y + Radius, Centre.Z),
                new Point(Centre.X - Radius, Centre.Y - Radius, Centre.Z + Height)
                );
        }

        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * (Height + Radius);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
        public override string ToString()
        {
            return "Centre: " + Centre + "Radius: " + Radius + "\nHeight: " + Height;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Cylinder cylinder)
            {
                return cylinder.Centre.Equals(Centre) &&
                    cylinder.Radius == Radius &&
                    cylinder.Height == Height;
            }
            return false;
        }

        public  override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode() ^ Height.GetHashCode();
        }
    }
}

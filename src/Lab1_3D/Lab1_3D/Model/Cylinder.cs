using System;

namespace Lab1_3D.Model
{
    internal class Cylinder: Figure3D
    {
        public Point Centre { get; init; }
        public double Radius { get; init; }
        public double Height { get; init; }
        public Cylinder()
        {
            Centre = new Point();
        }
        public Cylinder(Point centre, double radius, double height)
        {
            Centre = centre;
            Radius = radius;
            Height = height;
        }
        public Cylinder(double x, double y, double z, double radius, double height)
        {
            Centre = new Point(x, y, z);
            Radius = radius;
            Height = height;
        }
        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * (Radius + Height);
        }

        public override int GetVolume()
        {
            return (int)(Math.PI * Math.Pow(Radius, 2) * Height);
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped(new(Centre.X + Radius, Centre.Y - Radius, Centre.Z), new(Centre.X - Radius, Centre.Y + Radius, Centre.Z + Height));
        }

        public override string ToString()
        {
            return $"{Centre} {Radius} {Height}";
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            else
            {
                var cylinder = (Cylinder)obj;
                return Centre.Equals(cylinder.Centre) && Radius == cylinder.Radius && Height == cylinder.Height;
            }
        }
        public override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode() ^ Height.GetHashCode();
        }
    }
}

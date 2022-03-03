using System;

namespace Laba1.Model
{
    public class Cylinder : Figure3D
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
        public override double GetArea()
        {
            return 2 * Math.PI * Radius * (Radius + Height);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped(
                new(Centre.X + Radius, Centre.Y - Radius, Centre.Z),
                new(Centre.X - Radius, Centre.Y + Radius, Centre.Z + Height));
        }
        public override string ToString()
        {
            return $"Centre: {Centre}\nRadius: {Radius}\nHeight: {Height}\n";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            var cylinder = (Cylinder)obj;
            return Centre.Equals(cylinder.Centre) && Radius == cylinder.Radius && Height == cylinder.Height;
        }

        public override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode() ^ Height.GetHashCode();
        }
    }
}

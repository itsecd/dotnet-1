using System;

namespace Laba1.Model
{
    public class Sphere : Figure3D
    {
        public Point Centre { get; init; }
        public double Radius { get; init; }
        public Sphere()
        {
            Centre = new Point();
        }
        public Sphere(Point centre, double radius)
        {
            Centre = centre;
            Radius = radius;
        }
        public Sphere(double x, double y, double z, double radius)
        {
            Centre = new Point(x, y, z);
            Radius = radius;
        }
        public override double GetArea()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetVolume()
        {
            return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped
                (new(Centre.X + Radius, Centre.Y - Radius, Centre.Z - Radius),
                 new(Centre.X - Radius, Centre.Y + Radius, Centre.Z + Radius));
        }
        public override string ToString()
        {
            return $"Centre: {Centre}\nRadius: {Radius}\n";
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
            var sphere = (Sphere)obj;
            return Centre.Equals(sphere.Centre) && Radius == sphere.Radius;
        }

        public override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode();
        }
    }
}


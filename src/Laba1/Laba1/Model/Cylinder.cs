using System;

namespace Laba1.Model
{
    public class Cylinder : Figure3D
    {
        public Point Centre { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public Cylinder(Point centre, double radius, double height)
        {
            Centre = centre;
            Radius = radius;
            Height = height;
        }

        public override double GetArea()
        {
            return (2 * Math.PI * Radius * (Radius + Height));
        }

        public override double GetVolume()
        {
            return (Math.PI * Math.Pow(Radius, 2) * Height);
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped
                (new(Centre.X + Radius, Centre.Y - Radius, Centre.Z), 
                 new(Centre.X - Radius, Centre.Y + Radius, Centre.Z + Height));
        }
    }
}

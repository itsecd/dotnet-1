using System;

namespace Laba1.Model
{
    public class Sphere : Figure3D
    {
        public Point Centre { get; set; }
        public double Radius { get; set; }
        public Sphere( Point centre, double radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public override double GetArea()
        {
            throw new NotImplementedException();
        }

        public override double GetV()
        {
            throw new NotImplementedException();
        }

        public override RectangularParallelepiped GetBbox()
        {
            throw new NotImplementedException();
        }
    }
}

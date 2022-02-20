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

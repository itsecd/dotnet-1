using System;

namespace Laba1.Model
{
    public class RectangularParallelepiped : Figure3D
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public RectangularParallelepiped(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;

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

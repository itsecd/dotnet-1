using Lab1.Model;
using System;

namespace Lab1.Shapes
{
    public class Ball : Figure
    {

        public Point Centre { get; init; }

        public int Radius { get; init; }

        public Ball()
        {
            Radius = 0;
            Centre = new Point();
        }

        public Ball(Point centre, int radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(Centre.X + Radius, Centre.Y + Radius, Centre.Z + Radius),
                new Point(Centre.X - Radius, Centre.Y - Radius, Centre.Z - Radius)
                );
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetVolume()
        {
            return 4 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        public override string ToString()
        {
            return "Centre: " + Centre + "Radius: " + Radius;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Ball ball)
            {
                return ball.Centre.Equals(Centre) && ball.Radius == Radius;
            }
            return false;
        }

        public  override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode();
        }

    }
}

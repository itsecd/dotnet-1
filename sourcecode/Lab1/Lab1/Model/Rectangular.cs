using System;

namespace Lab1.Model
{
    public class Rectangular : Figure
    {
        public Point BaseLeftTop { get; set; }

        public Point BaseRightBottom { get; set; }

        public double Depth { get; set; }

        public double Width => Math.Abs(BaseLeftTop.X - BaseRightBottom.X);

        public double Height => Math.Abs(BaseLeftTop.Y - BaseRightBottom.Y);

        public Rectangular()
        {

        }

        public Rectangular(Point vertex1, Point vertex2)
        {
            BaseLeftTop = vertex1;
            BaseRightBottom = vertex2;
        }

        public override double GetSurfaceArea()
        {
            return 2 * Width * Height + 2 * Width * Depth + 2 * Height * Depth;
        }

        public override double GetVolume()
        {
            return Width * Height * Depth;
        }

        public override string ToString()
        {
            return "(" + BaseLeftTop.X + "," + BaseLeftTop.Y + "," + BaseLeftTop.Z + ")" + " "
                   + "(" + BaseRightBottom.X + "," + BaseRightBottom.Y + "," + BaseRightBottom.Z + ")" + " "
                   + "Depth: " + Depth;

        }

        public override bool Equals(object? obj)
        {
            if (obj is not Rectangular rec) return false;
            return BaseLeftTop.Equals(rec.BaseRightBottom) && BaseRightBottom.Equals(rec.BaseRightBottom) && Depth == rec.Depth;
        }
    }
}

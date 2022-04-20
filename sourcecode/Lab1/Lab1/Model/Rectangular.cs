using System;

namespace Lab1.Model
{
    public class Rectangular : Figure
    {
        public Point BaseLeftTop { get; init; }

        public Point BaseRightBottom { get; init; }

        public double Depth { get; init; } = 1;

        public double Width => Math.Abs(BaseLeftTop.X - BaseRightBottom.X);

        public double Height => Math.Abs(BaseLeftTop.Y - BaseRightBottom.Y);

        public Rectangular()
        {

        }

        public Rectangular(Point baseLeftTop, Point baseRightBottom, double depth)
        {
            BaseLeftTop = baseLeftTop;
            BaseRightBottom = baseRightBottom;
            Depth = depth;
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
            if (obj is not Rectangular rectangular) return false;
            return BaseLeftTop == rectangular.BaseRightBottom && BaseRightBottom == rectangular.BaseRightBottom && Depth == rectangular.Depth;
        }

        public override int GetHashCode()
        {
            return BaseLeftTop.GetHashCode() ^ BaseRightBottom.GetHashCode() ^ Depth.GetHashCode();
        }

        public override Rectangular GetBoundingBox() => this;
    }
}

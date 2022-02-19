using System;
using System.Xml.Serialization;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.Model.Figures
{
    [Serializable]
    [XmlRoot("RectangularCuboid")]
    public class RectangularCuboid : Figure
    {
        [XmlElement("Point_1")]
        public Point P1 { get; set; }
        [XmlElement("Point_2")]
        public Point P2 { get; set; }

        public RectangularCuboid()
        {
            P1 = new Point();
            P2 = new Point();
        }

        public RectangularCuboid(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public double GetWidth()
        {
            return Math.Abs(P1.X - P2.X);
        }

        public double GetLength()
        {
            return Math.Abs(P1.Y - P2.Y);
        }

        public double GetHeight()
        {
            return Math.Abs(P1.Z - P2.Z);
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(P1.X, P1.Y, P1.Z ),
                new Point(P2.X, P2.Y, P2.Z )
                );
        }

        public override double GetPerimeter()
        {
            return 2 * (GetHeight() * GetWidth() + GetWidth() * GetLength() + GetLength() * GetHeight());
        }

        public override double GetSquare()
        {
            return GetHeight() * GetWidth() * GetLength();
        }

        public override string ToString()
        {
            return "1: " + P1 + "2: " + P2;
        }

        public override bool Equals(Object obj)
        {
            try
            {
                RectangularCuboid rectangularCuboid = obj as RectangularCuboid;
                return rectangularCuboid.P1.Equals(P1) &&
                rectangularCuboid.P2.Equals(P2);
            }
            catch(Exception)
            {
                throw new NullReferenceException();
            }     
        }
    }
}

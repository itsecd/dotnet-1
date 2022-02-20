using System;
using System.Xml.Serialization;

namespace VolumetricFigures.Model.Figures
{
    [Serializable]
    [XmlRoot("Cylinder")]
    public class Cylinder : Figure
    {
        [XmlElement("Point")]
        public Point CentreFoundation { get; init; }
        [XmlElement("Radius")]
        public double Radius { get; init; }
        [XmlElement("Height")]
        public double Height { get; init; }

        public Cylinder()
        {
            Radius = 0;
            Height = 0;
            CentreFoundation = new Point();
        }

        public Cylinder(Point centreFoundation, double radius, double height)
        {
            CentreFoundation = centreFoundation;
            Radius = radius;
            Height = height;
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(CentreFoundation.X + Radius, CentreFoundation.Y + Radius, CentreFoundation.Z), 
                new Point( CentreFoundation.X - Radius, CentreFoundation.Y - Radius, CentreFoundation.Z + Height )
                );
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius * (Height + Radius);
        }

        public override double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
        public override string ToString()
        {
            return "Centre: " + CentreFoundation + "Radius: " + Radius + "\nHeight: " + Height;
        }

        public override bool Equals(Object obj)
        {
            if ((obj != null) && obj is Cylinder)
            {
                Cylinder cylinder = obj as Cylinder;
                return cylinder.CentreFoundation.Equals(CentreFoundation) &&
                    cylinder.Radius == Radius &&
                    cylinder.Height == Height;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CentreFoundation.GetHashCode() ^ Radius.GetHashCode() ^ Height.GetHashCode();
        }
    }
}

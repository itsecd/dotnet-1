using System;
using System.Xml.Serialization;

namespace VolumetricFigures.Model.Figures
{
    [Serializable]
    [XmlRoot("Sphere")]
    public class Sphere : Figure
    {
        [XmlElement("Point")]
        public Point Centre { get; set; }
        [XmlElement("Radius")]
        public double Radius { get; set; }

        public Sphere()
        {
            Radius = 0;
            Centre = new Point();
        }

        public Sphere(Point centre, double radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point(Centre.X + Radius , Centre.Y + Radius, Centre.Z + Radius ), 
                new Point( Centre.X - Radius, Centre.Y - Radius, Centre.Z - Radius )
                );
        }

        public override double GetPerimeter()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetSquare()
        {
            return 4 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        public override string ToString()
        {
            return "Centre: " + Centre + "Radius: " + Radius;
        }

        public override bool Equals(Object obj)
        {
            try
            {
                Sphere sphere = obj as Sphere;
                return sphere.Centre.Equals(Centre) && 
                    sphere.Radius == Radius;
            }
            catch(Exception)
            {
                throw new NullReferenceException();
            }
        }

        public override int GetHashCode()
        {
            return Centre.GetHashCode() ^ Radius.GetHashCode();
        }
    }
}

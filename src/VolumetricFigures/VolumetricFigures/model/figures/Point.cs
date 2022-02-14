using System;
using System.Xml.Serialization;

namespace VolumetricFigures.model.figures
{
    [Serializable]
    [XmlRoot("Point")]
    public class Point : Counting
    {
        [XmlElement("X")]
        public double x { get; set; }
        [XmlElement("Y")]
        public double y { get; set; }
        [XmlElement("Z")]
        public double z { get; set; }

        public Point()
        {
        }


        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override RectangularCuboid GetMinCuboid()
        {
            return new RectangularCuboid(
                new Point( 0, 0, 0 ), 
                new Point( 0, 0, 0 )
                );
        }

        public override double GetPerimeter()
        {
            return 0;
        }

        public override double GetSquare()
        {
            return 0;
        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y + " z: " + z + "\n";
        }

        public override bool Equals(Object obj)
        {
            Point p = obj as Point; 
            return p.x == x && 
                p.y == y && 
                p.z == z;   
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }
    }
}

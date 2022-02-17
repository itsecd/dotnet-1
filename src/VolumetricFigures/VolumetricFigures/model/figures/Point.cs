using System;
using System.Xml.Serialization;

namespace VolumetricFigures.model.figures
{
    [Serializable]
    [XmlRoot("Point")]
    public struct Point
    {
        [XmlElement("X")]
        public double x { get; set; }
        [XmlElement("Y")]
        public double y { get; set; }
        [XmlElement("Z")]
        public double z { get; set; }


        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y + " z: " + z + "\n";
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y &&
                   z == point.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
    }
}

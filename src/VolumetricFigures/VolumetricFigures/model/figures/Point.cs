using System;
using System.Xml.Serialization;

namespace VolumetricFigures.Model.Figures
{
    [Serializable]
    [XmlRoot("Point")]
    public struct Point
    {
        [XmlElement("X")]
        public double X { get; init; }
        [XmlElement("Y")]
        public double Y { get; init; }
        [XmlElement("Z")]
        public double Z { get; init; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "x: " + X + " y: " + Y + " z: " + Z + "\n";
        }

        public override bool Equals(object obj)
        {
            if ((obj != null) && obj is Point)
            {
                return obj is Point point &&
                   X == point.X &&
                   Y == point.Y &&
                   Z == point.Z;
            }
            return false;
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }
}

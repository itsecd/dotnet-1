using System;

namespace Lab1cs.Model
{
    public class Rectangular : Figure
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public double height;
        public double A => Math.Abs(Point1.X - Point2.X);
        public double B => Math.Abs(Point1.Y - Point2.Y);

        public Rectangular()
        {
         
        }
        public Rectangular(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
        public Rectangular(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Point1 = new Point(x1, y1, z1);
            Point2 = new Point(x2, y2, z2);
            Point2 = new Point(x2, y2, z2);
        }
        public override double acreage()
        {
            return 2 * A * B + 2 * A * height + 2 * B * height;
        }

        public override double volume()
        {
            return A * B * height;
        }
        public override string ToString()
        {
            return "(" + Point1.X + "," + Point1.Y + "," + Point1.Z + ")" + " "
                   + "(" + Point2.X + "," + Point2.Y + "," + Point2.Z + ")" + " "
                   + "height: " + height;

        }
        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Rectangular rec = (Rectangular)obj;
                return Point1.Equals(rec.Point1) && Point2.Equals(rec.Point2) && height == rec.height;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class Globular : Figure
    {
        public Point Center { get; set; }
        public double radius;
        public double pi = 3.14;
        public Globular()
        {
            Center = new Point(0, 0, 0);
            radius = 0;
        }
        public Globular(Point point, double r)
        {
            Center = point;
            radius = r;
        }
        public Globular(double x, double y, double z, double r)
        {
            Center = new Point(x, y, z);
            radius = r;
        }
        public override double acreage()
        {
            return 4 * pi * radius * radius;
        }

        public override double volume()
        {
            return 4 / 3 * pi * radius * radius * radius;
        }
        public override string ToString()
        {
            return "(" + Center.X + "," + Center.Y + "," + Center.Z + ")" + " " + "Radius: " + radius;
        }
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            else
            {
                Globular g = (Globular)obj;
                return Center.Equals(g.Center) && radius == g.radius;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class Sphere : Figure
    {
        public Point Center { get; set; }
        private double radius;
        public readonly double pi = Math.PI;
        public Sphere()
        {
        }
        public Sphere(Point center, double r)
        {
            Center = center;
            radius = r;
        }

        public override double SurfaceArea()
        {
            return 4 * pi * radius * radius;
        }

        public override double volume()
        {
            return 4 / 3 * pi * radius * radius * radius;
        }
        public override string ToString()
        {
            return "(" + Center.x + "," + Center.y + "," + Center.z + ")" + " " + "Radius: " + radius;
        }
        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            else
            {
                Sphere sphere = (Sphere)obj;
                return Center.Equals(sphere.Center) && radius == sphere.radius;
            }
        }
    }
}

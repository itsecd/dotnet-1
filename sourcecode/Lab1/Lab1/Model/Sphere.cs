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

        public override bool Equals(object? obj)
        {
            if (obj is not Sphere sphere) return false;
            return Center.Equals(sphere.Center) && radius == sphere.radius;
        }

        public Rectangular MinRectangular()
        {
            var rectangular = new Rectangular();
            var vertex1 = rectangular.Vertex1;
            var vertex2 = rectangular.Vertex2;
            vertex1.x = Center.x - radius;
            vertex1.y = Center.y - radius;
            vertex1.z = Center.z - radius;
            vertex2.x = Center.x + radius;
            vertex2.y = Center.y + radius;
            vertex2.z = Center.z - radius;
            rectangular.Height = 2 * radius;
            return rectangular;
        }
    }
}

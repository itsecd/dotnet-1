﻿using System;

namespace Laba1.Model
{
    public class Sphere : Figure3D
    {
        public Point Centre { get; set; }
        public double Radius { get; set; }
        public Sphere( Point centre, double radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public override double GetArea()
        {
            return (4 * Math.PI * Math.Pow(Radius, 2));
        }

        public override double GetVolume()
        {
            return ((4 / 3) * Math.PI * Math.Pow(Radius, 3));
        }

        public override RectangularParallelepiped GetMinParallelepiped()
        {
            return new RectangularParallelepiped
                (new(Centre.X + Radius, Centre.Y - Radius, Centre.Z - Radius),
                 new(Centre.X - Radius, Centre.Y + Radius, Centre.Z + Radius));
        }

    }
}


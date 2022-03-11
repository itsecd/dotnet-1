using System;

namespace Lab1.Model
{
    public class Rectangular : Figure
    {
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        private double height;
        public double Length => Math.Abs(Vertex1.X - Vertex2.X);
        public double Width => Math.Abs(Vetrex1.Y - Vertex2.Y);

        public double Height
        {
            get => height;
            set { height = value; }
        }

        public Rectangular()
        {
         
        }

        public Rectangular(Point vertex1, Point vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public override double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public override double volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            return "(" + Vertex1.x + "," + Vertex1.y + "," + Vertex1.z + ")" + " "
                   + "(" + Vertex2.x + "," + Vertex2.y + "," + Vertex2.z + ")" + " "
                   + "height: " + Height;

        }
        
         public override bool Equals(object? obj)
        {
            if (obj is not Rectangular rec) return false;
            return Vertex1.Equals(rec.Vertex2) && Vertex2.Equals(rec.Vertex2) && Height == rec.Height;
        }
    }
}

using System;

namespace Lab1.Model
{
    public struct Point
    {
        private double X;

        public double x
        {
            get => X;
            set { X = value; }
        }
    
        private double Y;

        public double y
        {
            get => Y;
            set { Y = value;}
        }
       

        public Point(double x, double y) { X = x; Y = y; }


        public double Distance(Point A) => Math.Sqrt((A.X - X) * (A.X - X) + (A.Y - Y) * (A.Y - Y));

        public override string ToString() => $"[{X},{Y}]";
        public override bool Equals(object? obj)
        {
            if (obj is Point point) return point.X == X && point.Y == Y;
            else return false;
        }

    }
}

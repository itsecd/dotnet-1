using System;

namespace Lab1.Mode
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


        public double Distance(Point A)
        {
            return Math.Sqrt((A.X - X) * (A.X - X) + (A.Y - Y) * (A.Y - Y));
        }


        public override string ToString()
        {
            return $"[{X},{Y}]";
        }

    }



}

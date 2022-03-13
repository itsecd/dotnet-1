using System;

namespace Lab1.Model
{
    public struct Point
    {
        private double _x;
        public double X
        {
            get => _x;
            set { _x = value; }
        }
        private double _y;
        public double Y
        {
            get => _y;
            set { _y = value; }
        }

        public Point(double x, double y) { _x = x; _y = y; }

        public double Distance(Point point) => Math.Sqrt((point._x - _x) * (point._x - _x) + (point._y - _y) * (point._y - _y));

        public override string ToString()
        {
            return $"[{_x},{_y}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Point point) return false;
            else return point._x == _x && point._y == _y;
        }

    }



}

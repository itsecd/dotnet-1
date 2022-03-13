using System;


namespace Lab1.Model
{
    public class Circle : Figure
    {
        private Point _center;
        public Point Center {
            get => _center;
            set { _center = value; }
        }

        private double _radius;
        public double Radius {
            get => _radius;
            set { _radius = value; }
        }

        public Circle() {  }
        public Circle(Circle circle)
        {
            _center = circle._center;
            _radius = circle._radius;
        }

        public Circle(Point center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public override double Perimeter() => Math.PI * 2 * _radius;

        public override double Square() => Math.PI * _radius * _radius;

        public override Rectangle MinBoundingBox()
        {
            var minBoundingBox = new Rectangle(new Point(_center.X + _radius, _center.Y + _radius), new Point(_center.X + _radius, _center.Y - _radius), new Point(_center.X - _radius, _center.Y - _radius), new Point(_center.X - _radius, _center.Y + _radius));
            return minBoundingBox;
        }

        public override string ToString() => $"Circle: ({_center.ToString()}, {_radius})";

        public override bool Equals(object? obj)
        {
            if (obj is not Circle circle) return false;
            else return circle._center.Equals(_center) && circle._radius == _radius;
        }

    }
}

namespace Lab1.Model
{
    public class Square : Figure
    {
        public Point Point { get; set; }

        public double A { get; set; }

        public Square()
        {
        }

        public Square(Point point, double a)
        {
            Point = point;
            A = a;
        }

        public Square(double x, double y, double a)
        {
            Point = new Point(x, y);
            A = a;
        }

        public override double GetLength()
        {
            return 4 * A;
        }

        public override string ToString()
        {
            return $"{Point.X} {Point.Y} {A}";
        }
    }
}

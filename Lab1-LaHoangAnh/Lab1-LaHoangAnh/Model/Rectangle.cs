

namespace Lab1.Model
{
    public class Rectangle : Figure
    {
        public Point A { get; init; }
        public Point B { get; init; }
        public Point C { get; init; }
        public Point D { get; init; }


        public Rectangle()
        {
            A = new Point(0, 0);
            B = new Point(0, 1);
            C = new Point(1, 1);
            D = new Point(1, 0);
        }
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double Perimeter()
        {
           
            return A.Distance(B) + B.Distance(C) + C.Distance(D) + D.Distance(A);
            
        }

        public override double Square()
        {
   
            return A.Distance(B) * B.Distance(C);
            
        }

        public override Rectangle MinBoundingFigure()
        {
            return this;
        }

        public override string ToString()
        {
            
            return $"Rectangle: ({A.ToString()},{B.ToString()},{C.ToString()},{D.ToString()})";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if (obj.ToString() == this.ToString())
                {
                    return true;
                }

                else return false;
            }
            else return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Mode
{
    public class Tritangle : Figure
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        private bool isTritangle;

        public Tritangle()
        {
            A = new Point(0, 0);
            B = new Point(0, 1);
            C = new Point(1, 0);
            isTritangle = true;
        }

        public Tritangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            double AB = A.Distance(B);
            double BC = B.Distance(C);
            double CA = C.Distance(A);
            if (AB + BC == CA || Math.Abs(AB - BC) == CA)
            {
                isTritangle = false;
            }
            else isTritangle = true;
        }

        public override double Perimeter()
        {
            double AB = A.Distance(B);
            double BC = B.Distance(C);
            double CA = C.Distance(A);
            if (isTritangle == false) return -1;
            return AB + BC + CA;
        }

        public override double Square()
        {
            double AB = A.Distance(B);
            double BC = B.Distance(C);
            double CA = C.Distance(A);
            double p = this.Perimeter() / 2;
            if (isTritangle == false) return -1;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

        public override Figure MinFigure()
        {
            if (isTritangle == false)
            {
                return this;
            }
            double t1 = ((B.X - A.X) * (B.X - C.X) + (B.Y - A.Y) * (B.Y - C.Y)) / ((B.X - C.X) * (B.X - C.X) + (B.Y - C.Y) * (B.Y - C.Y));
            double t2 = ((C.X - A.X) * (B.X - C.X) + (C.Y - A.Y) * (B.Y - C.Y)) / ((B.X - C.X) * (B.X - C.X) + (B.Y - C.Y) * (B.Y - C.Y));
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Point P1 = new Point(A.X + (B.X - C.X) * t1, A.Y + (B.Y - C.Y) * t1);
            Point P2 = new Point(A.X + (B.X - C.X) * t2, A.Y + (B.Y - C.Y) * t2);
            Console.WriteLine(P1.ToString());
            Console.WriteLine(P2.ToString());
            Figure Result = new Rectangle(B, C, P2, P1);

            return Result;
        }
        public override string ToString()
        {
            if (isTritangle == false) return $"Figure is not tritangle!";
            return $"Tritangle: ({A.ToString()}, {B.ToString()}, {C.ToString()})";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if (obj.ToString() == this.ToString()) return true;
                else return false;
            }
            else return false;
        }
    }
}

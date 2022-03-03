using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Mode
{
    public class Rectangle : Figure
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        private bool isRectangle;


        public Rectangle()
        {
            A = new Point(0, 0);
            B = new Point(0, 1);
            C = new Point(1, 1);
            D = new Point(1, 0);
            isRectangle = true;
        }
        public Rectangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            double AB = A.Distance(B);
            double BC = B.Distance(C);
            double CD = C.Distance(D);
            double DA = D.Distance(A);
            double AC = A.Distance(C);
            double BD = B.Distance(D);

            if (AB == CD && DA == BC && AC == BD)
            {
                isRectangle = true;
            }
            else isRectangle = false;
        }

        public override double Perimeter()
        {
            if (isRectangle == true)
            {
                return A.Distance(B) + B.Distance(C) + C.Distance(D) + D.Distance(A);
            }
            else return -1;
        }

        public override double Square()
        {
            if (isRectangle == true)
            {
                return A.Distance(B) * B.Distance(C);
            }
            else return -1;
        }

        public override Figure MinFigure()
        {
            return this;
        }

        public override string ToString()
        {
            if (isRectangle == false) return $"Figure is not rectangle";
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

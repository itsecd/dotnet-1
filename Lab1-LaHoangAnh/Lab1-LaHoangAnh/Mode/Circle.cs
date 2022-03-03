using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Mode
{
    public class Circle : Figure
    {
        public Point O { get; set; }
        public double R;

        public Circle() { O = new Point(0, 0); R = 0; }
        public Circle(Circle P)
        {
            O = P.O;
            R = P.R;
        }

        public Circle(Point o, double r)
        {
            O = o;
            R = r;
        }

        public override double Perimeter()
        {
            return Math.PI * 2 * R;
        }

        public override double Square()
        {
            return Math.PI * R * R;
        }

        public override Figure MinFigure()
        {
            Figure Result = new Rectangle(new Point(O.X + R, O.Y + R), new Point(O.X + R, O.Y - R), new Point(O.X - R, O.Y - R), new Point(O.X - R, O.Y + R));
            return Result;
        }

        public override string ToString()
        {
            return $"Circle: ({O.ToString()}, {R})";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PromLab01
{
    [Serializable]
    [XmlRoot("Rectangle")]
    public class Rectangle : Figure, ICalculations
    {
        [XmlElement("FirstPoint")]
        Point a;
        public Point A
        {
            get { return a; }
            set { a = value; }
        }

        [XmlElement("SecondPoint")]
        Point b;
        public Point B
        {
            get { return b; }
            set { b = value; }  
        }
        public Rectangle(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        public Rectangle(Point a, double width)
        {
            this.a = a;
            b = new Point (a.X + width, a.Y - width);

        }
        public Rectangle()
        {
            this.a = new Point(0);
            this.b = new Point(0);
        }

        public override double GetArea()
        {
            return Math.Abs(b.X-a.X)*Math.Abs(b.Y-a.Y);
        }

        public override double GetPerimeter()
        {
            return 2*Math.Abs(b.X - a.X) + 2* Math.Abs(b.Y - a.Y);
        }

        public override Rectangle GetBorders()
        {
            return new Rectangle(a, b);
        }

        public override string ToString()
        {
            return "{" + a.ToString() + ";" + b.ToString() + "}";
        }
    }
}

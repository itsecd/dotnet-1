using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumetricFigures.model.figures
{
    public class Point : Counting
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override double[,] GetMinCuboid()
        {
            return new double[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public override double GetPerimeter()
        {
            return 0;
        }

        public override double GetSquare()
        {
            return 0;
        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y + " z: " + z + "\n";
        }

        public override bool Equals(Object obj)
        {
            Point p = obj as Point; 
            return p.x == x && p.y == y && p.z == z;   
        }  
    }
}

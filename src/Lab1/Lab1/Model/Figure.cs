using Lab1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public abstract class Figure
    {
        public abstract double GetVolume();
        public abstract double GetSurfaceArea();
        public abstract RectangularParallelepiped GetMinimalFramingParalelepiped();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}

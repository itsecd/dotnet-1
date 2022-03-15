using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public abstract class Figure
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract Rectangle GetMinRectangle();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

    }
}

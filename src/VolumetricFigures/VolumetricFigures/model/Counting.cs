using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumetricFigures.model
{
    public abstract class Counting
    {
        public abstract double GetSquare();
        public abstract double GetPerimeter();    
        public abstract double[,] GetMinCuboid();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}

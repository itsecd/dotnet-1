using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromLab01
{
    internal interface ICalculations
    {
        double GetArea();
        double GetPerimeter();
        Rectangle GetBorders();
        void ToString();
    }
}

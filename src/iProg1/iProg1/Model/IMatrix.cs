using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iProg1.Model
{
    public interface IMatrix
    {
        int[] GetDimension();
        double GetValue(int indexC, int indexR);
        void SetValue(int indexC, int indexR,  int value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class FunctionComparator
    {
        public FunctionComparator() { }
        public List<Function> Sort(List<Function> list)
        {
            List<string> functionTypes = new List<string>()
                { "ConstantFunction", "LinearFunction", "QuadraticFunction", "SinusFunction", "CosinusFunction" };
            int tmpIndex = 0;
            for (int i = 0; i < functionTypes.Count; i++)
            {
                for (int j = tmpIndex; j < list.Count; j++)
                {
                    if (list[j].GetType().Name == functionTypes[i])
                    {
                        list.Insert(tmpIndex, list[j]);
                        list.RemoveAt(j + 1);
                        tmpIndex++;
                    }
                }
            }
            return list;
        }
    }
}

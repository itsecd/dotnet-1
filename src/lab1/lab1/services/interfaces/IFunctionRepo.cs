using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace lab1.services.interfaces
{
    internal interface IFunctionRepo
    {
        void Clear();
        List<Function> GetAll();
        void Insert(int index, Function newFunc);
        void RemoveAt(int index);
    }
}

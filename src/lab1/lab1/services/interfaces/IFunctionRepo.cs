using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace lab1.services.interfaces
{
    public interface IFunctionRepo
    {
        void Clear();
        List<Function> GetAll();
        void Insert(int index, Function newFunc);
        void Delete(int index);
        void AddFunction(Function function);
        bool CompareFunction(int index1, int index2);

    }
}

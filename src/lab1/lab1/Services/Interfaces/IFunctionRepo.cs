using System.Collections.Generic;
using Model;

namespace Lab1.Services.Interfaces
{
    public interface IFunctionRepo
    {
        void Clear();
        List<Function> GetAll();
        void Insert(int index, Function newFunc);
        void Delete(int index);
        void AddFunction(Function function);

    }
}

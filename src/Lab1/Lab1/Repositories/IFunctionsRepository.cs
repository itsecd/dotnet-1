using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        void AddFunction(Function function);
        bool CompareFunction(int index1, int index2);
        List<Function> GetFunction();
        void InsertFunction(Function function, int index);
        void DeleteAllFunction();
        void DeleteFunction(int index);
    }
}
using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        void AddFunction(Function function);
        bool ComparisonFunctions(int index1, int index2);
        void InsertFunction(int index, Function function);
        void RemoveAllFunctions();
        void RemoveFunction(int index);
        List<Function> GetFunctions();
    }
}
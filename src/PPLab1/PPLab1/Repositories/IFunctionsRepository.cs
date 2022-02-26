using PPLab1.Model;
using System.Collections.Generic;

namespace PPLab1.Repositories
{
    public interface IFunctionsRepository
    {
        void AddFunction(Function function);
        bool ComparisonFunctions(int index1, int index2);
        List<Function> GetFunctions();
        void InsertFunction(Function function, int index);
        void RemoveAllFunctions();
        void RemoveFunction(int index);
    }
}
using Lab1.Models;

using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        List<Function> GetFunctions();
        void AddFunction(Function function);
        void RemoveFunction(int index);
        void Clear();

    }
}
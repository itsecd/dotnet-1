using Lab1.Models;
using Spectre.Console;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        List<Function> GetFunctions();
        int GetCountFunctions();
        void InsertFunction(int index, Function function);
        void RemoveFunction(int index);
        void Clear();
        Function? GetFunction(int index);
    }
}
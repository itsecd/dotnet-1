using Lab1.Models;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        List<Function> GetFunctions();
        void InsertFunction(int index, Function function);
        void RemoveFunction(int index);
        void Clear();
    }
}
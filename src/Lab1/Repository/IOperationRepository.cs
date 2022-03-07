using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repository
{
    public interface IOperationRepository
    {
        void Insert(int index, Operation operation);
        bool CompareOperations(int lhsIndex, int rhsIndex);
        List<Operation> GetAll();
        void Clear();
        void RemoveAt(int index);
    }
}
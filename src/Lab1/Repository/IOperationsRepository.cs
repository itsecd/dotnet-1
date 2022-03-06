using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repository
{
    public interface IOperationsRepository
    {
        void AddOperation(int index, Operation operation);
        bool CompareOperations(int lhsIndex, int rhsIndex);
        List<Operation> GetAllOperations();
        string MinOperation(int lhs, int rhs);
        string MinOperationLinq(int lhs, int rhs);
        void RemoveCollection();
        void RemoveOperation(int index);
    }
}
using PromProgLab1.Model;
using System.Collections.Generic;

namespace PromProgLab1.Repositories
{
    public interface IOperationRepository
    {
        void AddOperation(int index, Operation operation);
        bool CompareOperations(int lhsIndex, int rhsIndex);
        List<Operation> GetOperations();
        string MinElement(int leftNumber, int rightNumber);
        void RemoveCollection();
        void RemoveOperation(int index);
    }
}
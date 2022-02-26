using Binary_operations.Models;
using System.Collections.Generic;

namespace Binary_operations.Repositories
{
    public interface IOperationRepository
    {
        public void AddOperation(int index, Operation operation);
        public void RemoveCollection();
        public void RemoveOperation(int index);
        public string MinElement(int leftNumber, int rightNumber);
        public bool CompareOperations(int lhsIndex, int rhsIndex);
        public List<Operation> GetOperations();

        public string MinElementLinq(int leftNumber, int rightNumber);
    }
}
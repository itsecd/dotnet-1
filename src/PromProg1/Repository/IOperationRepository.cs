using PromProg1.Models;
using System.Collections.Generic;

namespace PromProg1.Repository
{
    public interface IOperationRepository
    {
        List<Operation> GetOperations();
        void InsertOperation(int index, Operation operation);
        void RemoveOperation(int index);
        void ClearCollection();
        int CompareTwoOperations(int index1stOperation, int index2ndOperation, double operand1, double operand2);
        string FindMin(double operand1, double operand2);
        string FindMinLinq(double operand1, double operand2);
    }
}
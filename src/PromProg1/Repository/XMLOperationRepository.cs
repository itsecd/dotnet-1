using PromProg1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace PromProg1.Repository
{
    public class XMLOperationRepository : IOperationRepository
    {
        private const string StorageFileName = "operations.xml";

        private List<Operation> _operations;

        private void ReadFromFile()
        {
            if (_operations != null) return;

            if (!File.Exists(StorageFileName))
            {
                _operations = new List<Operation>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _operations = (List<Operation>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _operations);
        }

        public void InsertOperation(int index, Operation operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            ReadFromFile();
            _operations.Insert(index, operation);
            WriteToFile();
        }

        public void RemoveOperation(int index)
        {
            ReadFromFile();
            _operations.RemoveAt(index);
            WriteToFile();
        }

        public void ClearCollection()
        {
            ReadFromFile();
            _operations.Clear();
            WriteToFile();
        }

        public int CompareTwoOperations(int index1stOperation, int index2ndOperation, double operand1, double operand2)
        {
            ReadFromFile();
            if (_operations[index1stOperation].GetResult(operand1, operand2) < _operations[index2ndOperation].GetResult(operand1, operand2))
                return -1;
            else if (_operations[index1stOperation].GetResult(operand1, operand2) == _operations[index2ndOperation].GetResult(operand1, operand2))
                return 0;
            else
                return 1;
        }

        public List<Operation> GetOperations()
        {
            ReadFromFile();
            return _operations;
        }


        public string FindMin(double operand1, double operand2)
        {
            ReadFromFile();
            string minOperation;
            if (_operations.Count == 0)
            {
                return null;
            }
            double minResult = _operations[0].GetResult(operand1, operand2);
            foreach (var operation in _operations)
            {
                if (minResult > operation.GetResult(operand1, operand2))
                {
                    minResult = operation.GetResult(operand1, operand2);
                    minOperation = operation.ToString();
                }
            }
            return minOperation;
        }

        public string FindMinLinq(double operand1, double operand2)
        {
            return(_operations.First(operation => operation.GetResult(operand1, operand2) == _operations.Min(operation => operation.GetResult(operand1, operand2))).ToString());
        }
    }
}

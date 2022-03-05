using System.IO;
using Lab1.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System;

namespace Lab1.Repository
{
    public class XmlOperationsRepository : IXmlOperationsRepository
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

        public void AddOperation(int index, Operation operation)
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

        public void RemoveCollection()
        {
            ReadFromFile();
            _operations.Clear();
            WriteToFile();
        }

        public bool CompareOperations(int lhsIndex, int rhsIndex)
        {
            ReadFromFile();
            if (_operations[lhsIndex].Equals(_operations[rhsIndex]))
                return true;
            return false;
        }

        public List<Operation> GetAllOperations()
        {
            ReadFromFile();
            return _operations;
        }

        public string MinOperation(int lhs, int rhs)
        {
            ReadFromFile();

            int minValue = int.MaxValue;
            var minOperation = "Not operations";

            foreach (var operation in _operations)
            {
                if (operation.Compute(lhs, rhs) < minValue)
                {
                    minOperation = operation.ToString();
                    minValue = operation.Compute(lhs, rhs);
                }

            }
            return minOperation;
        }

    }
}

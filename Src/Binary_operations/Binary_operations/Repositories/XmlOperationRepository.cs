using Binary_operations.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Spectre.Console;

namespace Binary_operations.Repositories
{
    public class XmlOperationRepository : IOperationRepository
    {
        private const string StorageFileName = "operations.xml";
        private List<Operation> _operations;
        private void ReadFromFile()
        {
            if (_operations != null)
                return;

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

      
        public List<Operation> GetOperations()
        {
            ReadFromFile();
            return _operations;
        }
        public bool CompareOperations(int lhsIndex, int rhsIndex)
        {
            ReadFromFile();
            if (_operations[lhsIndex].Equals(_operations[rhsIndex]))
                return true;
            return false;
        }
       
        public void MinElement()
        {
            ReadFromFile();
            int min = int.MaxValue;
            foreach (var operationElement in _operations)
            {
                if (operationElement.GetResult() < min)
                    min = operationElement.GetResult();
            }
            AnsiConsole.MarkupLine("[orange1]Минимальная операция, найденная циклом: [/]" + min); 
            AnsiConsole.MarkupLine("[wheat1]Минимальная операция, найденная с помощью Linq: [/] " + _operations.Min(operation => operation.GetResult())); 
        }
    }
}

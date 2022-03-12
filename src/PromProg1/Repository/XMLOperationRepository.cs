using PromProg1.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            _operations.Clear();
            WriteToFile();
        }

        public List<Operation> GetOperations()
        {
            ReadFromFile();
            return _operations;
        }
    }
}

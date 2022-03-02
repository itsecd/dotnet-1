using Lab1.Operations;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlBinaryOperationsRepository : IBinaryOperationsRepository
    {
        private const string _filePath = "database.xml";
        private List<BinaryOperation> _operations;
        private void ReadFile()
        {
            if (_operations != null)
                return;

            if (!File.Exists(_filePath))
            {
                _operations = new();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<BinaryOperation>));
            using var fileStream = new FileStream(_filePath, FileMode.Open);
            _operations = (List<BinaryOperation>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<BinaryOperation>));
            using var fileStream = new FileStream(_filePath, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _operations);
        }

        public void AddOperation(int index, BinaryOperation operation)
        {
            ReadFile();
            _operations.Insert(index, operation);
            WriteFile();
        }

        public void RemoveOperation(int index)
        {
            ReadFile();
            _operations.RemoveAt(index);
            WriteFile();
        }

        public void RemoveAll()
        {
            ReadFile();
            _operations.RemoveAll(_ => true);
            WriteFile();
        }

        public List<BinaryOperation> GetAll()
        {
            ReadFile();
            return _operations;
        }
    }
}

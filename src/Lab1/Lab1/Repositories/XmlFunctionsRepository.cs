using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    internal class XmlFunctionsRepository : IFunctionsRepository
    {
        private const string _storageFileName = "function.xml";

        private List<Function> _functions;

        private void ReadFromFile()
        {
            if (_functions != null) return;

            if (!File.Exists(_storageFileName))
            {
                _functions = new List<Function>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(_storageFileName, FileMode.Open);
            _functions = (List<Function>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(_storageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _functions);
        }

        public void AddFunction(Function function)
        {
            if (function == null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            ReadFromFile();
            _functions.Add(function);
            WriteToFile();
        }

        public void InsertFunction(int index, Function function)
        {
            if (function == null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            ReadFromFile();

            if (_functions.Count == 0 || !_functions[index].Equals(function))
            {
                _functions.Insert(index, function);
                WriteToFile();
            }
        }

        public void RemoveFunction(int index)
        {
            ReadFromFile();
            _functions.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAllFunctions()
        {
            ReadFromFile();
            _functions.Clear();
            WriteToFile();
        }

        public bool ComparisonFunctions(int index1, int index2)
        {
            ReadFromFile();
            if (_functions[index1].Equals(_functions[index2]))
            {
                return true;
            }
            return false;
        }

        public List<Function> GetFunctions()
        {
            ReadFromFile();
            return _functions;
        }
    }
}

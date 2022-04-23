using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFunctionsRepository
    {
        private const string StorageFileName = "functions.xml";

        private List<Function> _functions;

        private void ReadFromFile()
        {
            if (_functions != null)
                return;

            if (!File.Exists(StorageFileName))
            {
                _functions = new List<Function>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, (FileMode.Open));
            _functions = (List<Function>)xmlSerializer.Deserialize(fileStream);
        }

        public void WriteToFile()
        { 
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, (FileMode.Create));
            xmlSerializer.Serialize(fileStream, _functions);
        }

        public void AddFunction(Function function)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));

            ReadFromFile();
            _functions.Add(function);
            WriteToFile();
        }

        public void RemoveFunction(int index)
        {
            ReadFromFile();
            _functions.RemoveAt(index);
            WriteToFile();
        }

        public void Clear(int index)
        {
            ReadFromFile();
            _functions.Clear();
            WriteToFile();
        }
    }
}

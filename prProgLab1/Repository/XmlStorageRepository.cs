using prProgLab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace prProgLab1.Repository
{
    class XmlStorageRepository : IFunctionsRepository
    {
        private const string StorageFileName = "functions.xml";

        private List<Function> _functionsList;

        public void Insert(int index, Function func)
        {
            ReadFromFile();
            if (index < 0)
            {
                _functionsList.Add(func);
                WriteToFile();
                return;
            }
            _functionsList.Insert(index, func);
            WriteToFile();
        }

        public void RemoveAt(int index)
        {
            ReadFromFile();
            _functionsList.RemoveAt(index);
            WriteToFile();
        }

        public List<Function> GetAll()
        {
            ReadFromFile();
            return _functionsList;
        }

        public void Clear()
        {
            ReadFromFile();
            _functionsList.Clear();
            WriteToFile();
        }

        public string MinFunc(int x)
        {
            ReadFromFile();
            if (_functionsList.Count == 0)
                return "";

            var min = _functionsList[0].GetDerivative().GetValue(x);
            var function = "";
            foreach (Function func in _functionsList)
            {
                if (func.GetDerivative().GetValue(x) < min)
                {
                    min = func.GetDerivative().GetValue(x);
                    function = func.ToString();
                }
            }
            return function;
        }


        public string MinFuncLINQ(int x)
        {
            ReadFromFile();
            var minValue = _functionsList.Min(func => func.GetDerivative().GetValue(x));
            return _functionsList.First(func => func.GetDerivative().GetValue(x) == minValue).ToString();
        }

        private void ReadFromFile()
        {
            if (_functionsList != null)
                return;

            if (!File.Exists(StorageFileName))
            {
                _functionsList = new List<Function>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _functionsList = (List<Function>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _functionsList);
        }
    }
}
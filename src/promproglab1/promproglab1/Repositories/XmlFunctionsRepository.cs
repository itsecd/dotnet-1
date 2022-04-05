﻿using promproglab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace promproglab1.Repositories
{
     public class XmlFunctionsRepository : IFunctionsRepository
    {
        private List<Function> _functions;

        private const string StorageFileName = "functions.xml";

        private void ReadFromFile()
        {
            if (_functions != null) return;

            if (!File.Exists(StorageFileName))
            {
                _functions = new List<Function>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _functions = (List<Function>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
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

        public void InsertFunction(int index, Function function)
        {
            ReadFromFile();
            if (_functions != null)
            {
                if (function == null)
                    throw new ArgumentNullException(nameof(function));

                if (index < 0 || index > _functions.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }


                _functions.Insert(index, function);
                WriteToFile();
                
            }
            else
            {
                ReadFromFile();
                _functions.Add(function);
                WriteToFile();
            }
        }


        public void RemoveFunction(int index)
        {
            ReadFromFile();
            _functions.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAllFunction()
        {
            ReadFromFile();
            _functions.RemoveRange(0, _functions.Count);
            WriteToFile();
        }

        public List<Function> GetFunctions()
        {
            ReadFromFile();
            return _functions;
        }
    }
}

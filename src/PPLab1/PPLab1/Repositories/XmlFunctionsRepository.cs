using PPLab1.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PPLab1.Repositories
{
    public class XmlFunctionsRepository : IFunctionsRepository
    {
        private const string StorageFileName = "functions.xml";

        private List<Function> _functions;

        private void ReadFromFile()
        {
            if (_functions != null) return;

            if (!File.Exists(StorageFileName))
            {
                _functions = new List<Function>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileReader = new FileStream(StorageFileName, FileMode.Open);
            _functions = (List<Function>)xmlSerializer.Deserialize(fileReader);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileWriter = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileWriter, _functions);
        }

        public void InsertFunction(Function function, int index)
        {
            if (_functions != null)
            {
                if (function == null)
                    throw new ArgumentNullException(nameof(function));
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (_functions[index] == null)
                {
                    ReadFromFile();
                    _functions.Insert(index, function);
                    WriteToFile();
                }
                else
                {
                    AnsiConsole.MarkupLine($"[skyblue1]Function already exists for this index.[/]" +
                        $"[skyblue1]The insertion is done at the end of the list.[/]");
                    ReadFromFile();
                    _functions.Add(function);
                    WriteToFile();
                }
            }
            else
            {
                ReadFromFile();
                _functions.Add(function);
                WriteToFile();
            }
        }

        public void AddFunction(Function function)
        {
            ReadFromFile();
            _functions.Add(function);
            WriteToFile();
        }

        public void RemoveFunction(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            ReadFromFile();
            if(_functions != null)
            {
                if (_functions.Count - 1 < index)
                {
                    WriteToFile();
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                else 
                {                
                    _functions.RemoveAt(index);
                    WriteToFile();
                }
            }
            else
            {
                WriteToFile();
                throw new ArgumentException("The list is empty");
            } 
        }

        public void RemoveAllFunctions()
        {
            ReadFromFile();
            _functions.RemoveRange(0, _functions.Count);
            WriteToFile();

        }

        public bool ComparisonFunctions(int index1, int index2)
        {
            ReadFromFile();
            if (_functions[index1] != null && _functions[index2] != null)
            {
                if (_functions[index1].GetType() == _functions[index2].GetType())
                {
                    return _functions[index1].Equals(_functions[index2]);
                }
                else
                    throw new ArgumentException("Mismatch of function types");
            }
            else
                throw new ArgumentException("Index is out of range");
        }

        public List<Function> GetFunctions()
        {
            ReadFromFile();
            return _functions;
        }
    }
}

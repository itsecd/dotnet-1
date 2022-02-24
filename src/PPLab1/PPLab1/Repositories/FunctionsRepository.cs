using PPLab1.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PPLab1.Repositories
{
    public class FunctionsRepository
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
            using var filereader = new FileStream(StorageFileName, FileMode.Open);
            _functions = (List<Function>)xmlSerializer.Deserialize(filereader);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var filewriter = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(filewriter, _functions);
        }

        public void AddFunction(Function function, int index)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if(_functions[index] == null)
            {
                ReadFromFile();
                _functions.Insert(index, function);
                WriteToFile();
            }
            else
            {
                ReadFromFile();
                _functions.Add( function);
                WriteToFile();
            }
        }

        public void RemoveFunction(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if(_functions[index] != null)
            {
                ReadFromFile();
                _functions.RemoveAt(index);
                WriteToFile();
            }
            else
                throw new ArgumentOutOfRangeException(nameof(index));

        }

        public void RemoveAllFunctions()
        {
            ReadFromFile();
            _functions.RemoveRange(0, _functions.Count -1) ;
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
                throw new ArgumentOutOfRangeException(nameof(index1),nameof(index2));
        }

        public void PrintFunctions()
        {
            var table = new Table();
            int counter = 0;

            table.AddColumn("Type");
            table.AddColumn("Function");
            table.AddColumn("Derivative");

            foreach (Function function in _functions)
            {
                if (counter < 10)
                {
                    table.AddRow(function.GetType().Name, function.ToString(),
                    function.derivative().ToString());
                    ++counter;
                }
                else
                {
                    table.AddRow("...", "...", "...");
                    break;
                }

            }
            AnsiConsole.Write(table);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Model;
using System.Xml.Serialization;
using System.IO;

namespace Lab1.FunctionsRepository
{
    class XMLFunctionsRepository : IFunctionsRepository
    {
        const string name = "Functions.xml";

        private List<Function> _functionsList;
        public Function this[int index]
        {
            get => _functionsList[index];
            set => _functionsList[index] = value;
        }

        public int Count
        {
            get
            {
                ReadFile();
                return _functionsList.Count;
            }
        }

        private void ReadFile()
        {
            if (!File.Exists(name))
            {
                _functionsList = new List<Function>();
                return;
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));

            try
            {
                using (var fs = new FileStream(name, FileMode.Open))
                {
                    var tmp = formatter.Deserialize(fs) as List<Function>;
                    if (tmp.Count != 0)
                        _functionsList = tmp;
                    else _functionsList = new List<Function>();
                }
            }
            catch (Exception)
            {
                _functionsList = new List<Function>();
            }
        }

        private void WriteToFile()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (FileStream fs = new FileStream(name, FileMode.Create))
            {
                formatter.Serialize(fs, _functionsList);
            }
        }

        public void Add(Function func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            ReadFile();
            _functionsList.Add(func);
            WriteToFile();
        }

        public void Clear()
        {
            ReadFile();
            _functionsList.Clear();
            WriteToFile();
        }

        public void Delete(int index) 
        {
            _functionsList.RemoveAt(index);
            WriteToFile();
        }

        public bool Compare(int i, int j)
        {
            ReadFile();
            return _functionsList[i].Equals(_functionsList[j]);
        }

        public Function GetMaxValueFunction(double x)
        {
            ReadFile();

            if (_functionsList.Count == 0)
                return null;

            var maxLst = _functionsList.OrderBy(f => f.GetValue(x));
            return maxLst.Last();
        }

        public override string ToString()
        {
            ReadFile();

            if (_functionsList.Count == 0)
                return "Контейнер пуст";

            string result = "";
            string dotes = "\n...";

            int end;
            if (_functionsList.Count <= 10)
            {
                end = _functionsList.Count;
                dotes = "";
            }
            else
                end = 10;

            for (int i = 0; i < end; ++i)
                result += $"\n{i + 1}) {_functionsList[i]}";
            result += dotes;

            return result;
        }
    }
}

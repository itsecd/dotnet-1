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

        List<Function> lst;
        public Function this[int index]
        {
            get => lst[index];
            set => lst[index] = value;
        }

        public int Count
        {
            get
            {
                ReadFile();
                return lst.Count;
            }
        }

        private void ReadFile()
        {
            if (!File.Exists(name))
            {
                lst = new List<Function>();
                return;
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));

            try
            {
                using (var fs = new FileStream(name, FileMode.Open))
                {
                    var tmp = formatter.Deserialize(fs) as List<Function>;
                    if (tmp.Count != 0)
                        lst = tmp;
                    else lst = new List<Function>();
                }
            }
            catch (Exception)
            {
                lst = new List<Function>();
            }

            return;
        }

        private void WriteToFile()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (FileStream fs = new FileStream(name, FileMode.Create))
            {
                formatter.Serialize(fs, lst);
            }

            return;
        }

        public void Add(Function func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            ReadFile();
            lst.Add(func);
            WriteToFile();
        }

        public void Clear()
        {
            ReadFile();
            lst.Clear();
            WriteToFile();
        }

        public void Delete(int index) 
        {
            lst.RemoveAt(index);
            WriteToFile();
        }

        public bool Compare(int i, int j)
        {
            ReadFile();
            return lst[i].Equals(lst[j]);
        }

        public Function GetMaxValueFunction(double x)
        {
            ReadFile();

            if (lst.Count == 0)
                return null;

            var maxLst = lst.OrderBy(f => f.GetValue(x));
            return maxLst.Last();
        }

        public override string ToString()
        {
            ReadFile();

            if (lst.Count == 0)
                return "Контейнер пуст";

            string result = "";
            string dotes = "\n...";

            int end;
            if (lst.Count <= 10)
            {
                end = lst.Count;
                dotes = "";
            }
            else
                end = 10;

            for (int i = 0; i < end; ++i)
                result += $"\n{i + 1}) {lst[i]}";
            result += dotes;

            return result;
        }
    }
}

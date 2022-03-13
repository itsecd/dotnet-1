using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functions;
using System.Xml.Serialization;
using System.IO;

namespace Lab1.FunctionsRepository
{
    class XMLFunctionsRepository : IFunctionsRepository
    {
        const string filename = "Functions.xml";

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

        private bool ReadFile()
        {
            if (!File.Exists(filename))
            {
                lst = new List<Function>();
                return false;
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var tmp = formatter.Deserialize(fs) as List<Function>;
                if (tmp.Count != 0)
                    lst = tmp;
            }

            return true;
        }

        private bool WriteToFile()
        {
            if (lst.Count == 0)
                return false;

            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, lst);
            }

            return true;
        }

        /*public void Add(double arg)
        {
            lst.Add(new PowerFunc(arg));
        }*/

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

        public void Delete(int index) // лучше просто перегрузить доступ по индексу
        {
            lst.RemoveAt(index);
            WriteToFile();
        }

        public bool Compare(int i, int j)
        {
            ReadFile();
            return lst[i].Equals(lst[j]);
        }

        public override string ToString()
        {
            ReadFile();
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

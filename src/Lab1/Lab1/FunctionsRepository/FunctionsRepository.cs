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
    class FunctionsRepository
    {
        const string filename = "Functions.xml";

        List<Function> lst;

        public bool ReadFile()
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

        public bool WriteFile()
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

        public void Add(double arg)
        {
            lst.Add(new PowerFunc(arg));
        }

        public void Clear()
        {
            lst.Clear();
        }

        public void Delete(int index) // лучше просто перегрузить доступ по индексу
        {
            lst.RemoveAt(index);
        }

        public bool Compare(int i, int j)
        {
            return lst[i].Equals(lst[j]);
        }

        public override string ToString()
        {
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
                result += $"\n{i+1}) {lst[i]}";
            result += dotes;

            return result;
        }
    }
}

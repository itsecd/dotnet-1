using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functions;
using System.Xml.Serialization;
using System.IO;
using AnsiConsole;
using Spectre.Console;

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

            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
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
                return false;
            }

            return true;
        }

        private bool WriteToFile()
        {
            /*if (lst.Count == 0)
                return false;*/

            XmlSerializer formatter = new XmlSerializer(typeof(List<Function>));
            //using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, lst);
            }

            return true;
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

        public Function? GetMaxValueFunction(double x)
        {
            ReadFile();

            if (lst.Count == 0)
                return null;

            var maxLst = lst.OrderBy(f => f.getValue(x));
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

        /*public override string ToString()
        {
            ReadFile();

            string result = "";
            for (int i = 0; i < lst.Count; ++i)
                result += $"\n{i + 1}) {lst[i]}";

            return result;
        }

        public void WriteFunctions()
        {
            ReadFile();

            var table = new Table();
            table.AddColumn("№");
            table.AddColumn("Функция");

            foreach(Function func in lst)
            {
                table.AddRow(func.GetType().Name, func.ToString());
            }
            Console.WriteLine(table.ToString());
        }*/
    }
}

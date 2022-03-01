using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Spectre.Console;

namespace Lab1
{
    class MatrixStorage
    {
        private List<Matrix> data;
        public Matrix this[int index] {get => data[index];}
        public int Count {get => data.Count;}

        public MatrixStorage() {data = new();}
        public void Insert(Matrix mat, int ind)
        {
            try
            {
                if (data.Count == 0)
                    data.Add(mat);
                else
                    data.Insert(ind, mat);
            }
            catch (ArgumentOutOfRangeException e)
            {
                AnsiConsole.WriteException(e);
            }
        }

        public void Delete(int ind)
        {
            try
            {
                data.RemoveAt(ind);
                AnsiConsole.Write(new Panel("[yellow]Матрица удалена[/]"));
                AnsiConsole.WriteLine();
            }
            catch (ArgumentOutOfRangeException e)
            {
                AnsiConsole.WriteException(e);
            }
        }

        public void Clear()
        {
            data.Clear();
            AnsiConsole.Write(new Panel("[yellow]Список очищен[/]"));
            AnsiConsole.WriteLine();
        }

        public int Compare(int ind1, int ind2)
        {
            try
            {
                if (data[ind1].Equals(data[ind2]))
                    return 1;
                return 0;
            }
            catch (ArgumentOutOfRangeException e)
            {
                AnsiConsole.WriteException(e);
                return -1;
            }
        }

        public void Dump()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Matrix>));
                using FileStream fd = new FileStream("matrices.xml", FileMode.Create);
                serializer.Serialize(fd, data);
                fd.Close();
            }
            catch (InvalidOperationException e)
            {
                AnsiConsole.WriteException(e);
            }
                
        }

        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Matrix>));
            using FileStream fd = new FileStream("matrices.xml", FileMode.OpenOrCreate);
            data = (List<Matrix>)serializer.Deserialize(fd);
            fd.Close();
        }

        public Table ToTable()
        {
            var tempTable = new Table();
            tempTable.AddColumns(new[] { "№", "Матрица" });
            for (int i = 0; i < data.Count && i != 10; i++)
                tempTable.AddRow(new[] { $"[bold blue]{i}[/]", data[i].ToString() });
            if (data.Count > 10)
                tempTable.AddRow(new[] { "...", "..." });
            return tempTable;
        }
    }
}
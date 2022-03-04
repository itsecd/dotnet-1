using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Spectre.Console;
using Lab1.Matrix;

namespace Lab1.Repository
{
    class MatrixStorage : IMatrixRepository
    {
        private List<AbstractMatrix> data;
        public AbstractMatrix this[int index] { get => data[index]; }
        public int Count { get => data.Count; }
        public MatrixStorage() { data = new(); }
        public void Insert(AbstractMatrix mat, int index = 0)
        {
            if (data.Count == 0)
                data.Add(mat);
            else
                data.Insert(index, mat);
        }

        public void Update(int index)
        {
            throw new NotImplementedException("Изменение матриц еще не реализовано.");
        }

        public void Delete(int ind)
        {
            data.RemoveAt(ind);
            AnsiConsole.Write(new Panel("[yellow]Матрица удалена[/]"));
            AnsiConsole.WriteLine();
        }

        public void Clear()
        {
            data.Clear();
            AnsiConsole.Write(new Panel("[yellow]Список очищен[/]"));
            AnsiConsole.WriteLine();
        }

        public int Compare(int ind1, int ind2)
        {
            if (data[ind1].Equals(data[ind2]))
                return 1;
            return 0;
        }

        public void Dump()
        {
            XDocument tmpDoc = XDocument.Load("matrices.xml");
            XElement root = tmpDoc.Element("Matrix");
            root.RemoveNodes();
            foreach (AbstractMatrix mat in data)
                root.Add(mat.ToXml());
            tmpDoc.Save("matrices.xml");
        }

        public void Load()
        {
            XDocument tmpDoc = XDocument.Load("matrices.xml");
            XElement root = tmpDoc.Element("Matrix");
            foreach (XElement mat in root.Elements())
            {
                if (mat.Name == "BufferedMatrix")
                    data.Add(new BufferedMatrix(mat));
                if (mat.Name == "SparseMatrix")
                    data.Add(new SparseMatrix(mat));
            }
        }

        public Table ToTable()
        {
            var tempTable = new Table();
            tempTable.AddColumns(new[] { "№", "Матрица" });
            for (int i = 0; i < data.Count && i != 10; i++)
                tempTable.AddRow(new[] { $"[bold blue]{i}[/]", data[i].ToString() });
            if (data.Count > 10)
                tempTable.AddRow(new[] { "...", "..." });
            if (data.Count == 0)
                tempTable.AddRow(new[] { "[red]-[/]", "[red]-[/]" });
            return tempTable;
        }
    }
}
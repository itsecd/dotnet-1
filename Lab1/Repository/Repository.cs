using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Spectre.Console;
using Lab1.Matrix;

namespace Lab1.Repository
{
    ///<summary>Класс, реализующий репозиторий для хранения матриц</summary>
    class MatrixStorage : IMatrixRepository
    {
        private List<AbstractMatrix> data;
        public AbstractMatrix this[int index] { get => data[index]; }
        public int Count { get => data.Count; }
        public MatrixStorage() { data = new(); }
        public void Insert(AbstractMatrix mat, int index = 0)
        {
            try
            {
                if (data.Count == 0)
                    data.Add(mat);
                else
                    data.Insert(index, mat);
            }
            catch (ArgumentOutOfRangeException e)
            { AnsiConsole.WriteException(e); }
        }

        public void Update(int index)
        {
            throw new NotImplementedException("Изменение матриц еще не реализовано.");
        }

        public void Delete(int index)
        {
            try
            { data.RemoveAt(index); }
            catch (ArgumentOutOfRangeException e)
            { AnsiConsole.WriteException(e); }
        }

        public void Clear()
        {
            data.Clear();
        }
        ///<summary>Сравнение матриц на равенство</summary>
        public int Compare(int ind1, int ind2)
        {
            try
            {
                if (data[ind1].Equals(data[ind2]))
                    return 1;
                return 0;
            }
            catch (ArgumentOutOfRangeException e)
            { AnsiConsole.WriteException(e); return -1; }
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
        ///<summary>Представление элементов в виде таблицы для вывода в консоль</summary>
        ///<returns>class Spectre.Console.Table</returns>
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
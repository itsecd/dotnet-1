using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Linq;
using Spectre.Console;
using Lab1.Matrix;

namespace Lab1.Repository
{
    ///<summary>Класс, реализующий репозиторий для хранения матриц</summary>
    class MatrixStorage : IMatrixRepository
    {
        private readonly List<AbstractMatrix> _data;
        private const string filePath = "matrices.xml";
        public AbstractMatrix this[int index] => _data[index];
        public int Count => _data.Count;
        public MatrixStorage() { _data = new(); }
        public void Insert(AbstractMatrix mat, int index = 0)
        {
            if (_data.Count == 0)
                _data.Add(mat);
            else
                _data.Insert(index, mat);
        }

        public void Update(int index)
        {
            throw new NotImplementedException("Изменение матриц еще не реализовано.");
        }

        public void Delete(int index)
        {
            _data.RemoveAt(index);
        }

        public void Clear()
        {
            _data.Clear();
        }
        ///<summary>Сравнение матриц на равенство</summary>
        public int Compare(int ind1, int ind2)
        {
            if (_data[ind1].Equals(_data[ind2]))
                return 1;
            return 0;
        }

        public void Dump()
        {
            XDocument tmpDoc = new XDocument();
            XElement root = new XElement("Matrix");
            foreach (AbstractMatrix mat in _data)
            {
                root.Add(mat.ToXml());
            }
            tmpDoc.Add(root);
            tmpDoc.Save(filePath);
        }

        public void Load()
        {
            if (File.Exists(filePath))
            {
                XDocument tmpDoc = XDocument.Load(filePath);
                foreach (XElement mat in tmpDoc.Element("Matrix").Elements())
                {
                    if (mat.Name == "BufferedMatrix")
                        _data.Add(new BufferedMatrix(mat));
                    if (mat.Name == "SparseMatrix")
                        _data.Add(new SparseMatrix(mat));
                }
            }
        }
        ///<summary>Представление элементов в виде таблицы для вывода в консоль</summary>
        ///<returns>class Spectre.Console.Table</returns>
        public Table ToTable()
        {
            var tempTable = new Table();
            tempTable.AddColumns("№", "Матрица");
            for (int i = 0; i < _data.Count && i != 10; i++)
                tempTable.AddRow($"[bold blue]{i}[/]", _data[i].ToString());
            if (_data.Count > 10)
                tempTable.AddRow("...", "...");
            if (_data.Count == 0)
                tempTable.AddRow("[red]-[/]", "[red]-[/]");
            return tempTable;
        }
    }
}
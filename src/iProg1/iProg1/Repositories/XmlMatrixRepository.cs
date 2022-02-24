using iProg1.Model;
using Spectre.Console;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace iProg1.Repositories
{
    public class XmlMatrixRepository : IMatrixRepository
    {
        private const string _storageFileName = "matrices.xml";

        public List<Matrix> _matrices;

        private bool _isLoaded = false;

        public XmlMatrixRepository()
        {
            _matrices = new List<Matrix>();
        }

        public int GetCount()
        {
            ReadFromFile();
            return _matrices.Count;
        }

        private void ReadFromFile()
        {
            if (_isLoaded)
            {
                return;
            }
            if (!File.Exists(_storageFileName) || new FileInfo(_storageFileName).Length == 0)
            {
                _matrices = new List<Matrix>();
                return;
            }
            using (var sr = new StreamReader(_storageFileName))
            {
                using (XmlTextReader reader = new XmlTextReader(sr))
                {
                    if (new FileInfo(_storageFileName).Length==0)
                    {
                        _matrices = new List<Matrix>();
                        return;
                    }
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    Helper.SkipToElement(reader);
                    if (int.Parse(reader.GetAttribute("size")) == 0)
                    {
                        _matrices = new List<Matrix>();
                        return;
                    }
                    reader.Read();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        Matrix tmp = reader.Name.Equals("SparseMatrix") ? new SparseMatrix() : new BufferedMatrix();
                        tmp.LoadFromXml(reader);
                        reader.ReadEndElement();
                        _matrices.Add(tmp);
                    }
                }
            }
            _isLoaded = true;
        }

        private void WriteToFile()
        {
            using (var fileStream = new FileStream(_storageFileName, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new XmlTextWriter(new StreamWriter(fileStream)))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("MatrixRepository");
                    writer.WriteAttributeString("size", _matrices.Count.ToString());
                    foreach (var matrix in _matrices)
                    {
                        writer.WriteStartElement(matrix.GetType().Name);
                        matrix.GetXml(writer);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
        }

        public void AddMatrix(Matrix matrix, int index)
        {
            ReadFromFile();
            _matrices.Insert(index, matrix);
            WriteToFile();
        }
        public void UpdateMatrix(int indexOfMatrix, int iIndex, int jIndex, double value)
        {
            ReadFromFile();
            _matrices[indexOfMatrix].SetValue(iIndex, jIndex, value);
            WriteToFile();
        }
        public void RemoveMatrix(int index)
        {
            ReadFromFile();
            _matrices.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAllMatrix()
        {
            ReadFromFile();
            _matrices.Clear();
            WriteToFile();
        }

        public bool Compare(int fstInd, int secInd)
        {
            ReadFromFile();
            return _matrices[fstInd].Equals(_matrices[secInd]);
        }

        public void OutputMatrix(int index)
        {
            ReadFromFile();
            var table = new Table();
            table.Title = new TableTitle($"{index} matrix").SetStyle("rapidblink");
            table.AddColumn("Type");
            table.AddColumn("Size");
            table.AddColumn("Matrix");
            table.AddRow(_matrices[index].GetType().Name,
                    $"({_matrices[index].GetDimension()},{_matrices[index].GetDimension()})",
                    _matrices[index].ToString());
            table.Columns[2].LeftAligned();
            AnsiConsole.Write(table);
        }
        public void OutputAllMatrix()
        {
            ReadFromFile();
            if (_matrices == null || _matrices.Count == 0)
            {
                AnsiConsole.WriteLine("[red]Repository is empty[/]");
            }
            var table = new Table();
            table.Title = new TableTitle("[mediumorchid1]Matrices[/]").SetStyle("rapidblink");
            table.AddColumn("Type");
            table.AddColumn("Size");
            table.AddColumn("Matrix");
            for (int i = 0; i < _matrices.Count; i++)
            {
                table.AddRow(_matrices[i].GetType().Name,
                    $"({_matrices[i].GetDimension()},{_matrices[i].GetDimension()})",
                    _matrices[i].ToString());
                if (i == 10)
                {
                    table.AddRow("...", "...", "...");
                    break;
                }
            }
            table.Border(TableBorder.DoubleEdge);
            AnsiConsole.Write(table);
        }
        public void PrintMinMaxAbsMatrixWithLinq()
        {
            ReadFromFile();
            var arr = from p in _matrices
                      orderby p.GetAbsMaxElement()
                      select p;
            OutputMatrix(_matrices.IndexOf(arr.First()));

        }
        public void PrintMinMaxAbsMatrix()
        {
            ReadFromFile();
            var arr = new double[_matrices.Count];
            int index = 0;
            double min = double.MaxValue;
            for (int i = 0;i < arr.Length; i++)
            {
                var absMax = _matrices[i].GetAbsMaxElement();
                if (absMax < min)
                {
                    min = absMax;
                    index = i;
                }
            }
            OutputMatrix(index);
        }
        public ValidationResult IsIndexInRange(int index)
        {
            ReadFromFile();
            if (index == -10)
            {
                return ValidationResult.Success();
            }
            if (index < 0)
            {
                return ValidationResult.Error("[red]The index must be greater than 0[/]");
            }
            if (index > _matrices.Count)
            {
                return ValidationResult.Error($"[red]The index must be less than {_matrices.Count}[/]");
            }
            return ValidationResult.Success();
        }
    }
}

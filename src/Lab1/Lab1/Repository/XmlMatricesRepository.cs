using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Spectre.Console;

namespace Lab1.Repository
{
    public class XmlMatricesRepository : IMatricesRepository
    {
        private const string _storageFileName = "matrices.xml";
        private List<Matrix> _matrices;

        private void ReadFromFile()
        {
            if (_matrices != null) return;

            if (!File.Exists(_storageFileName))
            {
                _matrices = new List<Matrix>();
                return;
            }
            using (var fileStream = new StreamReader(_storageFileName))
            {
                using (XmlTextReader reader = new XmlTextReader(fileStream))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    if (new FileInfo(_storageFileName).Length == 0)
                    {
                        _matrices = new List<Matrix>();
                        return;
                    }

                    while (reader.NodeType != XmlNodeType.Element)
                    {
                        reader.Read();
                    }
                    if (int.Parse(reader.GetAttribute("count")) == 0)
                    {
                        _matrices = new List<Matrix>();
                        return;
                    }
                    reader.Read();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        Matrix tmp = reader.Name.Equals("SparseMatrix") ?
                            new SparseMatrix(int.Parse(reader.GetAttribute("n")), int.Parse(reader.GetAttribute("m")), false) :
                            new BufferedMatrix(int.Parse(reader.GetAttribute("n")), int.Parse(reader.GetAttribute("m")), false);

                        tmp.LoadXml(reader);
                        reader.ReadEndElement();

                        if (_matrices == null)
                            _matrices = new List<Matrix>();
                        _matrices.Add(tmp);
                    }
                }
            }
        }

        private void WriteToFile()
        {
            using (var fileStream = new StreamWriter(_storageFileName))
            {
                using (var writer = new XmlTextWriter(fileStream))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("matrices");
                    writer.WriteAttributeString("count", _matrices.Count.ToString());
                    foreach (var matrix in _matrices)
                    {
                        writer.WriteStartElement(matrix.GetType().Name);
                        matrix.ToXml(writer);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
        }

        public void AddMatrix(Matrix matrix, int index)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            ReadFromFile();
            if (index < 0)
            {
                _matrices.Add(matrix);
                WriteToFile();
                return;
            }
            _matrices.Insert(index, matrix);
            WriteToFile();
        }

        public void RemoveMatrix(int index)
        {
            ReadFromFile();
            _matrices.RemoveAt(index);
            WriteToFile();
        }

        public List<Matrix> GetMatrices()
        {
            ReadFromFile();
            return _matrices;
        }

        public void PrintMatrices()
        {
            ReadFromFile();

            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Type");
            table.AddColumn("Size");
            table.AddColumn("Value");

            for (var i = 0; i < _matrices.Count(); i++)
            {
                table.AddRow(i.ToString(), _matrices[i].GetType().Name, _matrices[i].GetMatrixSize().ToString(), _matrices[i].ToString());
            }

            AnsiConsole.Write(table);
        }

        public void ClearRepository()
        {
            ReadFromFile();
            _matrices.Clear();
            WriteToFile();
        }

        public bool CompareMatrices(int index1, int index2)
        {
            var matrix1 = _matrices[index1];
            var matrix2 = _matrices[index2];
            return matrix1.Equals(matrix2);
        }
    }
}

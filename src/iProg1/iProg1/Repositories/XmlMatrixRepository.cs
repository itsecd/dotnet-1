using iProg1.Model;
using Spectre.Console;
using System;
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
            if (!File.Exists(_storageFileName))
            {
                _matrices = new List<Matrix>();
                return;
            }
            using (var sr = new StreamReader(_storageFileName))
            {
                using (XmlTextReader reader = new XmlTextReader(sr))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    Valid.SkipToElement(reader);
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
            using (var fileStream = new FileStream(_storageFileName, FileMode.OpenOrCreate))
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
            _matrices.Insert(index, matrix);
            WriteToFile();
        }

        public void RemoveMatrix(int index)
        {
            _matrices.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAllMatrix()
        {
            ReadFromFile();
            _matrices.Clear();
            WriteToFile();
        }

        public bool Compare(Matrix fst, Matrix sec)
        {
            return fst.Equals(sec);
        }

        public void Output()
        {
            ReadFromFile();
            if (_matrices == null || _matrices.Count == 0)
            {
                Console.WriteLine("Repository is empty");
            }
            int i = 0;
            foreach (var matrix in _matrices)
            {
                Console.WriteLine(matrix.ToString());
                i++;
                if (i == 10)
                {
                    Console.WriteLine("...");
                    break;
                }
            }
        }
        public ValidationResult isIndexInRange(int index)
        {
            ReadFromFile();
            if(index == -1)
            {
                return ValidationResult.Success();
            }
            if (index < 0)
            {
                return ValidationResult.Error("[red]The index must be greater than 0[/]");
            }
            if (index > _matrices.Count)
            {
                return ValidationResult.Error($"[red]The index must be less than { _matrices.Count}[/]");
            }
            return ValidationResult.Success();
        }
    }
}

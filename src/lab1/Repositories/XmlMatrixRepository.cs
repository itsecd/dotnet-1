using lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace lab1.Repositories
{
    public class XmlMatrixRepository : IMatrixRepository
    {
        private const string StorageFileName = "matrixes.xml";

        private List<IMatrix>? _matrices;

        private void ReadFromFile()
        {
            if (_matrices != null) return;

            if (!File.Exists(StorageFileName) || new FileInfo(StorageFileName).Length == 0)
            {
                _matrices = new List<IMatrix>();
                return;
            }

            using (var sr = new StreamReader(StorageFileName))
            {
                using (XmlTextReader reader = new XmlTextReader(sr))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    while (reader.NodeType != XmlNodeType.Element)
                        reader.Read();
                    _matrices = new List<IMatrix>();
                    reader.Read();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        IMatrix tmp = reader.Name.Equals("SparseMatrix") ?
                            new SparseMatrix(reader) :
                            new BufferedMatrix(reader);
                        reader.ReadEndElement();
                        _matrices.Add(tmp);
                    }
                }
            }
        }

        private void WriteToFile()
        {
            using (var fileStream = new FileStream(StorageFileName, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new XmlTextWriter(new StreamWriter(fileStream)))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("MatrixRepository");
                    if (_matrices == null)
                        throw new NullReferenceException();
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

        public bool Compare(int lhs, int rhs)
        {
            ReadFromFile();
            return _matrices![lhs].Equals(_matrices[rhs]);
        }

        public void Insert(int index, IMatrix? matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            ReadFromFile();
            _matrices!.Insert(index, matrix);
            WriteToFile();
        }

        public void RemoveAt(int index)
        {
            ReadFromFile();
            _matrices!.RemoveAt(index);
            WriteToFile();
        }

        public void Clear()
        {
            ReadFromFile();
            _matrices!.Clear();
            WriteToFile();
        }

        public IMatrix GetMatrix(int index)
        {
            ReadFromFile();
            return _matrices![index];
        }

        public List<IMatrix> GetAll()
        {
            ReadFromFile();
            return _matrices!;
        }

        public void SetValue(int index, int i, int j, double value)
        {
            ReadFromFile();
            _matrices![index].SetValue(i,j,value);
            WriteToFile();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iProg1.Model
{
    [Serializable]
    public class SparseMatrix : Matrix//, IXmlSerializable
    {
        private int _rowCount;
        private int _columnCount;
        private readonly Dictionary<Tuple<int, int>, double> _matrix;
        public SparseMatrix()
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
        }
        public SparseMatrix(int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            _rowCount = cCount;
            _columnCount = rCount;
        }
        public SparseMatrix(double[][] matrix)
        {
            if (matrix == null)
            {
                _rowCount = 0;
                _columnCount = 0;
                _matrix = null;
            }
            _rowCount = matrix.Length;
            _columnCount = matrix[0].Length;
            for(int i = 0; i < _rowCount; i++)
            {
                for(int j = 0;j < _columnCount; j++)
                {
                    if(matrix[i][j] != 0)
                    {
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i][j]);
                    }
                } 
            }
        }
        public SparseMatrix(Dictionary<Tuple<int, int>, double> matrix, int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            foreach (var pair in matrix)
            {
                _matrix.Add(pair.Key, pair.Value);
            }
            _rowCount = cCount;
            _columnCount = rCount;
        }
        public override int GetColumnCount()
        {
            return _rowCount;
        }
        public override int GetRowCount()
        {
            return _columnCount;
        }
        public override double GetValue(int indexC, int indexR)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix.ContainsKey(new Tuple<int, int>(indexC, indexR))
                ? _matrix[new Tuple<int, int>(indexC, indexR)]
                : 0;
        }
        public override void SetValue(int indexC, int indexR, int value)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                 !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            if (value == 0)
            {
                _matrix.Remove(new Tuple<int, int>(indexC, indexR));
            }
            else
            {
                _matrix[new Tuple<int, int>(indexC, indexR)] = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("SparseMatrix: \n");
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    if (_matrix.ContainsKey(tuple))
                    {
                        sb.Append(_matrix[tuple]);
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var matrix = (Matrix)obj;
            if (matrix.GetColumnCount() != _rowCount)
            {
                return false;
            }
            if (matrix.GetRowCount() != _columnCount)
            {
                return false;
            }
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    if (GetValue(i, j) != matrix.GetValue(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            double hashCode = 0;
            foreach (var el in _matrix)
            {
                hashCode += (el.Key.Item1 * el.Key.Item2 / el.Value) + 0.1483 * _rowCount;
                hashCode *= (el.Value * el.Key.Item1 * el.Key.Item2 + 8.56789) * _columnCount + 13;
            }
            return Math.Abs((int)hashCode);
        }
        public override void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("RowCount", _rowCount.ToString());
            writer.WriteAttributeString("ColumnCount", _columnCount.ToString());
            foreach (var el in _matrix)
            {
                writer.WriteStartElement("MatrixElement");
                writer.WriteAttributeString("I", el.Key.Item1.ToString());
                writer.WriteAttributeString("J", el.Key.Item2.ToString());
                writer.WriteAttributeString("Value", el.Value.ToString());
                writer.WriteEndElement();
            }
        }

        public override void LoadFromXml(XmlTextReader reader)
        {
            if (reader.IsEmptyElement)
                return;
            Valid.SkipToElement(reader);
            this._columnCount = int.Parse(reader.GetAttribute("RowCount"));
            this._rowCount = int.Parse(reader.GetAttribute("ColumnCount"));
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                _matrix.Add(new Tuple<int, int>(
                    int.Parse(reader.GetAttribute("I")),
                    int.Parse(reader.GetAttribute("J"))),
                    double.Parse(reader.GetAttribute("Value")));
                reader.Read();
            }
        }

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    bool wasEmpty = reader.IsEmptyElement;
        //    if (wasEmpty)
        //        return;
        //    this.ColumnCount = int.Parse(reader.GetAttribute("ColumnCount"));
        //    this.RowCount = int.Parse(reader.GetAttribute("RowCount"));
        //    reader.Read();
        //    while (reader.NodeType != XmlNodeType.EndElement)
        //    {
        //        _matrix.Add(new Tuple<int, int>(
        //            int.Parse(reader.GetAttribute("I")),
        //            int.Parse(reader.GetAttribute("J"))),
        //            double.Parse(reader.GetAttribute("Value")));
        //        reader.Read();
        //    }
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    writer.WriteAttributeString("ColumnCount", ColumnCount.ToString());
        //    writer.WriteAttributeString("RowCount", RowCount.ToString());
        //    foreach (var el in _matrix)
        //    {
        //        writer.WriteStartElement("MatrixElement");
        //        writer.WriteAttributeString("I", el.Key.Item1.ToString());
        //        writer.WriteAttributeString("J", el.Key.Item2.ToString());
        //        writer.WriteAttributeString("Value", el.Value.ToString());
        //        writer.WriteEndElement();
        //    }
        //}
    }
}

using System;
using System.Text;
using System.Xml;

namespace iProg1.Model
{
    [Serializable]
    public class BufferedMatrix : Matrix
    {
        public double[][] _matrix;
        public BufferedMatrix() {}
        public BufferedMatrix(int a, int b)
        {
            _matrix = new double[a][];
            for (int i = 0; i < a; i++)
            {
                _matrix[i] = new double[b];
            }
        }
        public BufferedMatrix(double[][] matrix)
        {
            _matrix = (double[][])matrix.Clone();
        }
        public override int GetColumnCount()
        {
            return _matrix.GetLength(0);
        }
        public override int GetRowCount()
        {
            return _matrix[0].Length;
        }
        public override double GetValue(int indexC, int indexR)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix[indexC][indexR];
        }
        public override void SetValue(int indexC, int indexR, int value)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            _matrix[indexC][indexR] = value;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BufferedMatrix: \n");
            for(int i = 0; i < _matrix.GetLength(0); i++)
            {
                for(int j = 0; j < _matrix[0].Length; j++)
                {
                    sb.Append(_matrix[i][j]);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            if(obj == null || this.GetType() != obj.GetType()) 
            {
                return false; 
            }
            var matrix = (BufferedMatrix)obj;
            if(matrix.GetColumnCount() != GetColumnCount()) 
            { 
                return false; 
            }
            if(matrix.GetRowCount() != GetRowCount()) 
            {
                return false; 
            }
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix[0].Length; j++)
                {
                    if (_matrix[i][j] != matrix._matrix[i][j])
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
            foreach(var el in _matrix)
            {
                foreach (var el2 in el)
                {
                    hashCode += el2 - 0.1488 * _matrix.GetLength(0);
                    hashCode *= (el2 + 1.11111) * 2.1444 * _matrix[0].Length;
                }
            }
            return Math.Abs((int)hashCode);
        }
        public override void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("ColumnCount", GetColumnCount().ToString());
            writer.WriteAttributeString("RowCount", GetRowCount().ToString());
            foreach (var el in _matrix)
            {
                foreach (var el2 in el)
                {
                    writer.WriteStartElement("MatrixElement");
                    writer.WriteAttributeString("Value", el2.ToString());
                    writer.WriteEndElement();
                }
            }
        }
        public override void LoadFromXml(XmlTextReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            if (wasEmpty)
                return;
            Valid.SkipToElement(reader);
            var columnCount = int.Parse(reader.GetAttribute("ColumnCount"));
            var RowCount = int.Parse(reader.GetAttribute("RowCount"));
            _matrix = new double[columnCount][];
            for (int i = 0; i < columnCount; i++)
            {
                _matrix[i] = new double[RowCount];
                for(int j = 0; j < RowCount; j++)
                {
                    reader.Read();
                    _matrix[i][j] = double.Parse(reader.GetAttribute("Value"));
                }
            }
            reader.Skip();
        }
    }
}

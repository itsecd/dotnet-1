using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace iProg1.Model
{
    public class BufferedMatrix : IMatrix
    {
        private readonly double[][] _matrix;
        public BufferedMatrix(int dimension)
        {
            _matrix = new double[dimension][];
            for (int i = 0; i < dimension; i++)
            {
                _matrix[i] = new double[dimension];
            }
        }

        public BufferedMatrix(double[][] matrix)
        {
            _matrix = (double[][])matrix.Clone();
        }
        
        public int GetDimension()
        {
            return _matrix.GetLength(0);
        }
        
        public double GetValue(int indexR, int indexC)
        {
            if (!Helper.IsValidIndex(indexR, GetDimension()) ||
                !Helper.IsValidIndex(indexC, GetDimension()))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return _matrix[indexR][indexC];
        }
        
        public void SetValue(int indexR, int indexC, double value)
        {
            if (!Helper.IsValidIndex(indexR, GetDimension()) ||
                !Helper.IsValidIndex(indexC, GetDimension()))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            _matrix[indexR][indexC] = value;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < GetDimension(); i++)
            {
                for(int j = 0; j < GetDimension(); j++)
                {
                    sb.Append($"{_matrix[i][j], 10}");
                    sb.Append(' ');
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
            if(obj == null || GetType() != obj.GetType()) 
            {
                return false; 
            }
            var matrix = (IMatrix)obj;
            if(matrix.GetDimension() != GetDimension()) 
            { 
                return false; 
            }
            for (int i = 0; i < GetDimension(); i++)
            {
                for (int j = 0; j < GetDimension(); j++)
                {
                    if (_matrix[i][j] != matrix.GetValue(i, j))
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
            foreach(var row in _matrix)
            {
                foreach (var elem in row)
                {
                    hashCode += elem - 0.1488 * _matrix.GetLength(0);
                    hashCode *= (elem + 1.11111) * 2.1444 * _matrix[0].Length;
                }
            }
            return Math.Abs((int)hashCode);
        }
        
        public void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("Dimension", GetDimension().ToString());
            foreach (var row in _matrix)
            {
                foreach (var elem in row)
                {
                    writer.WriteStartElement("MatrixElement");
                    writer.WriteAttributeString("Value", elem.ToString());
                    writer.WriteEndElement();
                }
            }
        }
        
        public void LoadFromXml(XmlTextReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            if (wasEmpty)
                return;
            Helper.SkipToElement(reader);
            for (int i = 0; i < _matrix.Length; i++)
            {
                _matrix[i] = new double[_matrix.Length];
                for(int j = 0; j < _matrix.Length; j++)
                {
                    reader.Read();
                    _matrix[i][j] = double.Parse(reader.GetAttribute("Value"));
                }
            }
            reader.Skip();
        }

        
        public double GetAbsMaxElementWithLinq()
        {
            return _matrix.Max(p => p.Max(Math.Abs));
        }

        public double GetAbsMaxElement()
        {
            double absMax = 0;
            for(int i = 0; i < _matrix.Length; i++)
            {
                for(int j = 0; j < _matrix[i].Length; j++)
                {
                    absMax = Math.Abs(_matrix[i][j]) > absMax ? _matrix[i][j] : absMax;
                }
            }
            return absMax;
        }
    }
}

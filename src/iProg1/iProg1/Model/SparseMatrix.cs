using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace iProg1.Model
{

    public class SparseMatrix : IMatrix
    {
        private readonly int _dimension;
        private readonly Dictionary<Tuple<int, int>, double> _matrix;
        public SparseMatrix()
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
        }
        public SparseMatrix(int dimension)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            _dimension = dimension;
        }
        public SparseMatrix(double[][] matrix)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            if (matrix == null)
            {
                _dimension = 0;
                return;
            }
            _dimension = matrix.Length;
            for(int i = 0; i < _dimension; i++)
            {
                for(int j = 0;j < _dimension; j++)
                {
                    if(matrix[i][j] != 0)
                    {
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i][j]);
                    }
                } 
            }
        }
        public SparseMatrix(Dictionary<Tuple<int, int>, double> matrix, int dimension)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            foreach (var (index, value) in matrix)
            {
                _matrix.Add(index, value);
            }
            _dimension = dimension;
        }
        public int GetDimension()
        {
            return _dimension;
        }
        public double GetValue(int indexR, int indexC)
        {
            if (!Helper.IsValidIndex(indexC, _dimension) ||
                !Helper.IsValidIndex(indexR, _dimension))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return _matrix.ContainsKey(new Tuple<int, int>(indexR, indexC))
                ? _matrix[new Tuple<int, int>(indexR, indexC)]
                : 0;
        }
        public void SetValue(int indexR, int indexC, double value)
        {
            if (!Helper.IsValidIndex(indexC, _dimension) ||
                 !Helper.IsValidIndex(indexR, _dimension))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (value == 0)
            {
                _matrix.Remove(new Tuple<int, int>(indexR, indexC));
            }
            else
            {
                _matrix[new Tuple<int, int>(indexR, indexC)] = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _dimension; i++)
            {
                for (int j = 0; j < _dimension; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    if (_matrix.ContainsKey(tuple))
                    {
                        sb.Append($"{_matrix[tuple],10}");
                    }
                    else
                    {
                        sb.Append($"{0, 10}");
                    }
                    sb.Append(' ');
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var matrix = (IMatrix)obj;
            if (matrix.GetDimension() != _dimension)
            {
                return false;
            }
            for (int i = 0; i < _dimension; i++)
            {
                for (int j = 0; j < _dimension; j++)
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
            foreach (var ((i, j), elem) in _matrix)
            {
                hashCode += (i * j / elem) + 0.1483 * _dimension;
                hashCode *= (elem * i * j + 8.56789) * _dimension + 13;
            }
            return Math.Abs((int)hashCode);
        }
        public void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("Dimension", _dimension.ToString());
            foreach (var ((i, j), elem) in _matrix)
            {
                writer.WriteStartElement("MatrixElement");
                writer.WriteAttributeString("I", i.ToString());
                writer.WriteAttributeString("J", j.ToString());
                writer.WriteAttributeString("Value", elem.ToString());
                writer.WriteEndElement();
            }
        }

        public void LoadFromXml(XmlTextReader reader)
        {
            if (reader.IsEmptyElement)
                return;
            Helper.SkipToElement(reader);
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

        public double GetAbsMaxElementWithLinq()
        {
            return _matrix.Values.Max();    
        }

        public double GetAbsMaxElement()
        {
            double absMax = 0;
            foreach (var elem in _matrix.Values)
            {
                absMax = absMax < Math.Abs(elem) ? elem : absMax;
            }
            return absMax;
        }
    }
}

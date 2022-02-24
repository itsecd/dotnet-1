using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace iProg1.Model
{

    public class SparseMatrix : Matrix
    {
        private int _dimension;
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
            if (matrix == null)
            {
                _dimension = 0;
                _matrix = null;
            }
            _matrix = new Dictionary<Tuple<int, int>, double>();
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
            foreach (var pair in matrix)
            {
                _matrix.Add(pair.Key, pair.Value);
            }
            _dimension = dimension;
        }
        public override int GetDimension()
        {
            return _dimension;
        }
        public override double GetValue(int indexR, int indexC)
        {
            if (!Helper.IsValidIndex(indexC, _dimension) ||
                !Helper.IsValidIndex(indexR, _dimension))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix.ContainsKey(new Tuple<int, int>(indexR, indexC))
                ? _matrix[new Tuple<int, int>(indexR, indexC)]
                : 0;
        }
        public override void SetValue(int indexR, int indexC, double value)
        {
            if (!Helper.IsValidIndex(indexC, _dimension) ||
                 !Helper.IsValidIndex(indexR, _dimension))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
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
                        sb.Append(String.Format("{0,11}", _matrix[tuple]));
                    }
                    else
                    {
                        sb.Append(String.Format("{0,11}", 0));
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
            foreach (var el in _matrix)
            {
                hashCode += (el.Key.Item1 * el.Key.Item2 / el.Value) + 0.1483 * _dimension;
                hashCode *= (el.Value * el.Key.Item1 * el.Key.Item2 + 8.56789) * _dimension + 13;
            }
            return Math.Abs((int)hashCode);
        }
        public override void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("Dimension", _dimension.ToString());
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
            Helper.SkipToElement(reader);
            this._dimension = int.Parse(reader.GetAttribute("Dimension"));
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

        public override double GetAbsMaxElementWithLinq()
        {
            var arr = new List<double>(_matrix.Values);
            var res = from p in arr
                      orderby p
                      select Math.Abs(p);
            return res.Last();
        }

        public override double GetAbsMaxElement()
        {
            var arr = new List<double>(_matrix.Values);
            arr.Sort((x, y) => (int)(Math.Abs(x)*100000 - Math.Abs(y)*100000));
            return arr[arr.Capacity-1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Lab1.Model
{
    public class SparseMatrix : Matrix
    {
        private readonly int _n;
        private readonly int _m;
        private readonly Dictionary<Tuple<int, int>, double> _matrix;

        public SparseMatrix() { }

        public SparseMatrix(int n, int m, bool fillRandom)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            this._n = n;
            this._m = m;
            if (!fillRandom) return;

            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
            }

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    matrix[i][j] = rand.Next(0, +20);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] != 0)
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i][j]);
                }
            }
        }

        public override int GetMatrixSize()
        {
            return _n * _m;
        }

        public override void PrintMatrix()
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    var ind = new Tuple<int, int>(i, j);
                    if (_matrix.ContainsKey(ind))
                        Console.Write(_matrix[ind] + "\t");
                    else
                        Console.Write("0 \t");

                }
                Console.WriteLine();
            }
        }

        public override double GetValueByIndex(int i, int j)
        {
            if (_matrix.ContainsKey(new Tuple<int, int>(i, j)))
                return _matrix[new Tuple<int, int>(i, j)];
            else
                return 0;
        }

        public override void SetValueByIndex(int i, int j, double value)
        {
            if (i < 0 || i >= _m)
                return;
            if (j < 0 || j >= _n)
                return;
            if (value == 0)
                _matrix.Remove(new Tuple<int, int>(i, j));
            else
                _matrix[new Tuple<int, int>(i, j)] = value;
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    var ind = new Tuple<int, int>(i, j);
                    if (_matrix.ContainsKey(ind))
                        str += ind + "=" + _matrix[ind];
                    else
                        str += ind + "=0";
                }
            }

            return str;

        }

        public override int GetHashCode()
        {
            double hashCode = 0;
            foreach (var ((i, j), elem) in _matrix)
            {
                hashCode *= elem.GetHashCode();
            }
            return Math.Abs((int)hashCode);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            var matrix = (Matrix)obj;
            if (matrix.GetMatrixSize() != GetMatrixSize())
            {
                return false;
            }
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    if (GetValueByIndex(i, j) != matrix.GetValueByIndex(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override double GetMaxElm()
        {
            double maxElm = 0;
            foreach (var elem in _matrix.Values)
            {
                if (maxElm < Math.Abs(elem))
                    maxElm = elem;
            }
            return maxElm;
        }
        public override double GetMaxElmLinq()
        {
            return _matrix.Values.Max();
        }

        public override void ToXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("_n", _n.ToString());
            writer.WriteAttributeString("_m", _m.ToString());
            foreach (var ((i, j), elem) in _matrix)
            {
                writer.WriteStartElement("elem");
                writer.WriteAttributeString("i", i.ToString());
                writer.WriteAttributeString("j", j.ToString());
                writer.WriteAttributeString("value", elem.ToString());
                writer.WriteEndElement();
            }
        }

        public override void LoadXml(XmlTextReader reader)
        {
            if (reader.IsEmptyElement) return;
            while (reader.NodeType != XmlNodeType.Element)
            {
                reader.Read();
            }
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                _matrix.Add(new Tuple<int, int>(
                    int.Parse(reader.GetAttribute("i")),
                    int.Parse(reader.GetAttribute("j"))),
                    double.Parse(reader.GetAttribute("value")));
                reader.Read();
            }
        }
    }
}
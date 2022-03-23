using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace lab1.Model
{
    public class SparseMatrix : IMatrix
    {

        private readonly Dictionary<Tuple<int, int>, double> _matrix;
        public int Width { get; init; }
        public int Height { get; init; }

        /// <summary>
        /// Create 2x2 matrix
        /// </summary>
        public SparseMatrix()
        {
            Width = 2;
            Height = 2;
            _matrix = new();
        }

        /// <summary>
        /// Create heightxwidth matrix
        /// </summary>
        /// <param name="height">count of rows </param>
        /// <param name="width">count of columns</param>
        public SparseMatrix(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new();
        }

        /// <summary>
        /// Create matrix from array
        /// </summary>
        /// <param name="matrix">two-dimensional array</param>
        public SparseMatrix(double[,] matrix)
        {
            Height = matrix.GetUpperBound(0) + 1;
            Width = matrix.GetUpperBound(1) + 1;
            _matrix = new();
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                {
                    if (matrix[i, j] != 0)
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i, j]);
                }
        }

        /// <summary>
        /// Create matrix from Xml
        /// </summary>
        /// <param name="reader">Xml reader</param>
        public SparseMatrix(XmlTextReader reader)
        {
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (!int.TryParse(reader.GetAttribute("Height"), out int tmp))
                throw new ArgumentException("Failed to parse the attribute 'Height'");
            Height = tmp;

            if (!int.TryParse(reader.GetAttribute("Width"), out tmp))
                throw new ArgumentException("Failed to parse the attribute 'Width'");
            Width = tmp;

            _matrix = new();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                while (reader.Name == "SparseMatrix")
                    reader.Read();
                if (!int.TryParse(reader.GetAttribute("i"), out int i))
                    throw new ArgumentException("Failed to parse the attribute 'i'");
                if (!int.TryParse(reader.GetAttribute("j"), out int j))
                    throw new ArgumentException("Failed to parse the attribute 'j'");
                if (!double.TryParse(reader.GetAttribute("Val"), out double val))
                    throw new ArgumentException("Failed to parse the attribute 'Val'");
                _matrix.Add(new Tuple<int, int>(i, j), val);
                reader.Read();
            }
        }

        /// <summary>
        /// Find maximum modulus
        /// </summary>
        /// <returns>Maximem modulus</returns>
        public double GetAbsMax()
        {
            var max = Double.NegativeInfinity;
            foreach (var num in _matrix)
            {
                if (Math.Abs(num.Value) > max)
                    max = Math.Abs(num.Value);
            }
            return max;
        }

        /// <summary>
        /// Return a value from the matrix by indexes
        /// </summary>
        /// <param name="i">first dimension index</param>
        /// <param name="j">second dimension index</param>
        /// <returns>value</returns>
        public double GetValue(int i, int j)
        {
            if (i >= Height)
                throw new ArgumentOutOfRangeException(nameof(i), $"Height must be not bigger than {Height}");
            if (j >= Width)
                throw new ArgumentOutOfRangeException(nameof(j), $"Width must be not bigger than {Width}");
            return _matrix.ContainsKey(new Tuple<int, int>(i, j)) ? _matrix[new Tuple<int, int>(i, j)] : 0;
        }

        /// <summary>
        /// Set a value to the matrix by indexes
        /// </summary>
        /// <param name="i">first dimension index</param>
        /// <param name="j">second dimension index</param>
        /// <param name="value">value</param>
        public void SetValue(int i, int j, double value)
        {
            if (i >= Height)
                throw new ArgumentOutOfRangeException(nameof(i), $"Height must be not bigger than {Height}");
            if (j >= Width)
                throw new ArgumentOutOfRangeException(nameof(j), $"Width must be not bigger than {Width}");
            if (value == 0)
                return;
            if (value == 0 && _matrix.ContainsKey(new Tuple<int, int>(i, j)))
                _matrix.Remove(new Tuple<int, int>(i, j));
            _matrix[new Tuple<int, int>(i, j)] = value;
        }

        /// <summary>
        /// Write matrix to Xml
        /// </summary>
        /// <param name="writer">Xml writer</param>
        public void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("Height", Height.ToString());
            writer.WriteAttributeString("Width", Width.ToString());
            foreach (var ((i, j), elem) in _matrix)
            {
                writer.WriteStartElement("Elem");
                writer.WriteAttributeString("i", i.ToString());
                writer.WriteAttributeString("j", j.ToString());
                writer.WriteAttributeString("Val", elem.ToString());
                writer.WriteEndElement();
            }
        }
        public override bool Equals(object? obj)
        {

            if (this == obj)
            {
                return true;
            }
            if (obj is not SparseMatrix)
            {
                return false;
            }
            var tmp = (SparseMatrix)obj;
            if (tmp.Height != Height || tmp.Width != Width)
            {
                return false;
            }
            foreach (var ((i, j), value) in _matrix)
            {
                if (tmp.GetValue(i, j) != value)
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_matrix.ContainsKey(new Tuple<int, int>(i, j)))
                        sb.Append($"{_matrix[new Tuple<int, int>(i, j)]} ");
                    else
                        sb.Append("0 ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int tmp = 1;
            double hash = Height + Width;
            foreach (var ((i, j), value) in _matrix)
            {
                hash += tmp * i + tmp * j + value;
                ++tmp;
            }
            return (int)Math.Round(hash);
        }
    }
}

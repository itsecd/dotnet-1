using System;
using System.Text;
using System.Xml;

namespace lab1.Model
{
    public class BufferedMatrix : IMatrix
    {
        private readonly double[,] _matrix;

        public int Width { get; init; }

        public int Height { get; init; }

        /// <summary>
        /// Create 2x2 matrix
        /// </summary>
        public BufferedMatrix()
        {
            Width = 2;
            Height = 2;
            _matrix = new double[Height, Width];
        }

        /// <summary>
        /// Create heightxwidth matrix
        /// </summary>
        /// <param name="height">count of rows </param>
        /// <param name="width">count of columns</param>
        public BufferedMatrix(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new double[Height, Width];
        }

        /// <summary>
        /// Create matrix from array
        /// </summary>
        /// <param name="matrix">two-dimensional array</param>
        public BufferedMatrix(double[,] matrix)
        {
            Height = matrix.GetUpperBound(0) + 1;
            Width = matrix.GetUpperBound(1) + 1;
            _matrix = new double[Height, Width];

            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                    _matrix[i, j] = matrix[i, j];
        }

        /// <summary>
        /// Create matrix from Xml
        /// </summary>
        /// <param name="reader">Xml reader</param>
        public BufferedMatrix(XmlTextReader reader)
        {
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (!int.TryParse(reader.GetAttribute("Height"), out int tmp))
                throw new ArgumentException("Failed to parse the attribute 'Height'");
            Height = tmp;

            if (!int.TryParse(reader.GetAttribute("Width"), out tmp))
                throw new ArgumentException("Failed to parse the attribute 'Width'");
            Width = tmp;

            _matrix = new double[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    reader.Read();
                    if (!double.TryParse(reader.GetAttribute("Val"), out _matrix[i, j]))
                        throw new ArgumentException("Failed to parse the attribute 'Val'");
                }
            }
            reader.Skip();
        }

        /// <summary>
        /// Find maximum modulus
        /// </summary>
        /// <returns>Maximem modulus</returns>
        public double GetMaxNorm()
        {
            var max = Double.NegativeInfinity;
            foreach (var num in _matrix)
            {
                if (Math.Abs(num) > max)
                    max = Math.Abs(num);
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
            return _matrix[i, j];
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
            _matrix[i, j] = value;
        }

        /// <summary>
        /// Write matrix to Xml
        /// </summary>
        /// <param name="writer">Xml writer</param>
        public void GetXml(XmlTextWriter writer)
        {
            writer.WriteAttributeString("Height", Height.ToString());
            writer.WriteAttributeString("Width", Width.ToString());
            foreach (var elem in _matrix)
            {
                writer.WriteStartElement("Num");
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
            if (obj is not BufferedMatrix)
            {
                return false;
            }
            var tmp = (BufferedMatrix)obj;
            if (tmp.Height != Height || tmp.Width != Width)
            {
                return false;
            }
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (_matrix[i, j] != tmp.GetValue(i, j))
                        return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append($"{_matrix[i, j]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
        public override int GetHashCode()
        {
            int tmp = 1;
            double hash = Height + Width;
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                {
                    hash += tmp * i + tmp * j + _matrix[i, j];
                    ++tmp;
                }
            return (int)Math.Round(hash);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Lab1.Model
{
    public class SparseMatrix : Matrix
    {

        private readonly Dictionary<(int, int), double> _matrix;
        public override int Width { get; init; }
        public override int Height { get; init; }

        public override double this[int i, int j]
        {
            get => _matrix.ContainsKey((i, j))? _matrix[(i, j)] : 0;

            set
            {
                if (value == 0 && _matrix.ContainsKey((i, j)))
                    _matrix.Remove((i, j));
                if (value != 0)
                    _matrix[(i, j)] = value;
            }
        }

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
            Height = matrix.GetLength(0);
            Width = matrix.GetLength(1);
            _matrix = new();
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                {
                    if (matrix[i, j] != 0)
                        _matrix.Add((i, j), matrix[i, j]);
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
                _matrix.Add((i, j), val);
                reader.Read();
            }
        }

        /// <summary>
        /// Find maximum modulus
        /// </summary>
        /// <returns>Maximem modulus</returns>
        public override double GetMaxNorm() =>_matrix.Max(n => Math.Abs(n.Value));


        /// <summary>
        /// Write matrix to Xml
        /// </summary>
        /// <param name="writer">Xml writer</param>
        public override void GetXml(XmlTextWriter writer)
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
    }
}

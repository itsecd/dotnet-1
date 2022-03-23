using System;
using System.Linq;
using System.Xml;

namespace Lab1.Model
{
    public class BufferedMatrix : Matrix
    {
        private readonly double[,] _matrix;

        public override int Width { get; init; }

        public override int Height { get; init; }

        public override double this[int i, int j]
        {
            get => _matrix[i, j];

            set => _matrix[i, j] = value;
        }

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
            //Height = matrix.GetUpperBound(0) + 1;
            Height = matrix.GetLength(0);
            //Width = matrix.GetUpperBound(1) + 1;
            Width = matrix.GetLength(1);
            _matrix = new double[Height, Width];

            //for (int i = 0; i < Height; ++i)
            //    for (int j = 0; j < Width; ++j)
            //        _matrix[i, j] = matrix[i, j];

            _matrix = (double[,])matrix.Clone();
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
        public override double GetMaxNorm() => _matrix.Cast<double>().Max(Math.Abs);

        /// <summary>
        /// Write matrix to Xml
        /// </summary>
        /// <param name="writer">Xml writer</param>
        public override void GetXml(XmlTextWriter writer)
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
    }
}
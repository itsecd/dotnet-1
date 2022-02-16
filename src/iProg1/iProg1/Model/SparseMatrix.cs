using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iProg1.Model
{
    public class SparseMatrix : IMatrix, IXmlSerializable
    {
        public int ColumnCount;
        public int RowCount;
        public Dictionary<Tuple<int, int>, double> _matrix;
        public SparseMatrix()
        {
            _matrix = new Dictionary<Tuple<int,int>, double>();
        }
        public SparseMatrix(int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            ColumnCount = cCount;
            RowCount = rCount;
        }
        public SparseMatrix(Dictionary<Tuple<int, int>, double> matrix, int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            foreach(var pair in matrix)
            {
                _matrix.Add(pair.Key, pair.Value);
            }
            ColumnCount = cCount;
            RowCount = rCount;
        }
        public int GetColumnCount()
        {
            return ColumnCount;
        }
        public int GetRowCount()
        {
            return RowCount;
        }
        public double GetValue(int indexC, int indexR)
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
        public void SetValue(int indexC, int indexR, int value)
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
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    if(_matrix.ContainsKey(tuple))
                    {
                        sb.Append(_matrix[tuple]);
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
            var matrix = (SparseMatrix)obj;
            if (matrix.GetColumnCount() != ColumnCount)
            {
                return false;
            }
            if (matrix.GetRowCount() != RowCount)
            {
                return false;
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    bool isExist = _matrix.ContainsKey(tuple);
                    if (isExist == matrix._matrix.ContainsKey(tuple) && isExist)
                    {
                        if (_matrix[tuple] != matrix._matrix[tuple])
                        {
                            return false;
                        }
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
                hashCode += (el.Key.Item1*el.Key.Item2/el.Value) + 0.1483 * ColumnCount;
                hashCode *= (el.Value*el.Key.Item1*el.Key.Item2 + 8.56789) * RowCount+13;
            }
            return Math.Abs((int)hashCode);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer dimensionAndKeySerializer = new XmlSerializer(typeof(int));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(double));
            bool wasEmpty = reader.IsEmptyElement;
            if (wasEmpty)
                return;
            this.ColumnCount = int.Parse(reader.GetAttribute("ColumnCount"));
            this.RowCount = int.Parse(reader.GetAttribute("RowCount"));
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {   
                _matrix.Add(new Tuple<int, int>(
                    int.Parse(reader.GetAttribute("I")),
                    int.Parse(reader.GetAttribute("J"))),
                    double.Parse(reader.GetAttribute("Value")));
                reader.Read();
            }
            //reader.ReadStartElement();
            //reader.ReadStartElement("colCount");
            //this.ColumnCount = (int)dimensionAndKeySerializer.Deserialize(reader);
            //reader.ReadEndElement();
            //reader.ReadStartElement("rowCount");
            //this.RowCount = (int)dimensionAndKeySerializer.Deserialize(reader);
            //reader.ReadEndElement();
            //while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            //{
            //    reader.ReadStartElement("MatrixElement");
            //    reader.ReadStartElement("key");
            //    reader.ReadStartElement("keyItem1");
            //    int keyItem1 = (int)dimensionAndKeySerializer.Deserialize(reader);
            //    reader.ReadEndElement();
            //    reader.ReadStartElement("keyItem2");
            //    int keyItem2 = (int)dimensionAndKeySerializer.Deserialize(reader);
            //    reader.ReadEndElement();
            //    reader.ReadEndElement();
            //    reader.ReadStartElement("value");
            //    double value = (double)valueSerializer.Deserialize(reader);
            //    reader.ReadEndElement();
            //    reader.ReadEndElement();
            //    _matrix.Add(new Tuple<int, int>(keyItem1, keyItem2), value);
            //}
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("ColumnCount", ColumnCount.ToString());
            writer.WriteAttributeString("RowCount", RowCount.ToString());
            foreach (var el in _matrix)
            {
                writer.WriteStartElement("MatrixElement");
                writer.WriteAttributeString("I", el.Key.Item1.ToString());
                writer.WriteAttributeString("J", el.Key.Item2.ToString());
                writer.WriteAttributeString("Value", el.Value.ToString());
                writer.WriteEndElement();

            }
            //XmlSerializer dimensionAndKeySerializer = new XmlSerializer(typeof(int));
            //XmlSerializer valueSerializer = new XmlSerializer(typeof(double));
            //writer.WriteStartElement("colCount");
            //dimensionAndKeySerializer.Serialize(writer, ColumnCount);
            //writer.WriteEndElement();
            //writer.WriteStartElement("rowCount");
            //dimensionAndKeySerializer.Serialize(writer, RowCount);
            //writer.WriteEndElement();
            //foreach (var el in _matrix)
            //{
            //    writer.WriteStartElement("MatrixElement");
            //    writer.WriteStartElement("key");
            //    writer.WriteStartElement("keyItem1");
            //    dimensionAndKeySerializer.Serialize(writer, el.Key.Item1);
            //    writer.WriteEndElement();
            //    writer.WriteStartElement("keyItem2");
            //    dimensionAndKeySerializer.Serialize(writer, el.Key.Item2);
            //    writer.WriteEndElement();
            //    writer.WriteEndElement();
            //    writer.WriteStartElement("value");
            //    valueSerializer.Serialize(writer, el.Value);
            //    writer.WriteEndElement();
            //    writer.WriteEndElement();
            //}
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace iProg1.Model
{
    public class BufferedMatrix : Matrix
    {
        private double[][] _matrix;
        public BufferedMatrix() {}
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
        
        public override int GetDimension()
        {
            return _matrix.GetLength(0);
        }
        
        public override double GetValue(int indexR, int indexC)
        {
            if (!Helper.IsValidIndex(indexR, GetDimension()) ||
                !Helper.IsValidIndex(indexC, GetDimension()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix[indexR][indexC];
        }
        
        public override void SetValue(int indexR, int indexC, double value)
        {
            if (!Helper.IsValidIndex(indexR, GetDimension()) ||
                !Helper.IsValidIndex(indexC, GetDimension()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
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
                    sb.Append(String.Format("{0,10}" ,_matrix[i][j]));
                    sb.Append(" ");
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
            var matrix = (Matrix)obj;
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
            writer.WriteAttributeString("Dimension", GetDimension().ToString());
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
            Helper.SkipToElement(reader);
            var dimension = int.Parse(reader.GetAttribute("Dimension"));
            _matrix = new double[dimension][];
            for (int i = 0; i < dimension; i++)
            {
                _matrix[i] = new double[dimension];
                for(int j = 0; j < dimension; j++)
                {
                    reader.Read();
                    _matrix[i][j] = double.Parse(reader.GetAttribute("Value"));
                }
            }
            reader.Skip();
        }

        
        public override double GetAbsMaxElementWithLinq()
        {
            return _matrix.Max(p => p.Max(z => Math.Abs(z)));
        }

        public override double GetAbsMaxElement()
        {
            double absMax = 0;
            for(int i = 0; i < _matrix.Length; i++)
            {
                double absMaxInRow = Math.Abs(_matrix[i][0]);
                for(int j = 1; j < _matrix[i].Length; j++)
                {
                    absMaxInRow = Math.Abs(_matrix[i][j]) > absMaxInRow ? _matrix[i][j] : absMaxInRow;
                }
                absMax = absMaxInRow > absMax ? absMaxInRow : absMax;
            }
            return absMax;
        }
    }
}

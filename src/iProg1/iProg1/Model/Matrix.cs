using System.Xml.Serialization;

namespace iProg1.Model
{
    [XmlInclude(typeof(SparseMatrix)),XmlInclude(BufferedMatrix)]
    public abstract class Matrix
    {
        public abstract int GetColumnCount();
        public abstract int GetRowCount();
        public abstract double GetValue(int indexC, int indexR);
        public abstract void SetValue(int indexC, int indexR,  int value);
    }
}

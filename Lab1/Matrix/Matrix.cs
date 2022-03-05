using System.Xml.Linq;

namespace Lab1.Matrix
{
    ///<summary>Абстрактный класс матриц</summary>
    public abstract class AbstractMatrix
    {
        ///<summary>Количество столбцов (ширина)</summary>
        public abstract int Width { get; }
        ///<summary>Количество строк (высота)</summary>
        public abstract int Height { get; }

        public abstract double this[int x, int y] {get; set;}
        ///<summary>Норма максимума модуля</summary>
        public abstract double Norm();
        ///<summary>Норма максимума модуля (LINQ)</summary>
        public abstract double NormL();
        public override string ToString() => $"Matrix [[{Height}x{Width}]]";
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        ///<summary>XML - представление матрицы, используемое для сериализации</summary>
        ///<returns>class System.Xml.Linq.XElement</returns>
        public abstract XElement ToXml();
    }
}
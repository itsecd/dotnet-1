using Lab1.Matrix;
using Spectre.Console;

namespace Lab1.Repository
{
    ///<summary>Интерфейс репозитория для хранения матриц</summary>
    public interface IMatrixRepository
    {
        AbstractMatrix this[int index] {get;}
        ///<summary>Количество элементов</summary>
        int Count {get;}
        ///<summary>Вставка нового элемента</summary>
        void Insert(AbstractMatrix mat, int index = 0);
        ///<summary>Изменение элемента по индексу</summary>
        void Update(int index);
        ///<summary>Удаление элемента по индексу</summary>
        void Delete(int index);
        ///<summary>Удаление всех элементов</summary>
        void Clear();
        ///<summary>Сериализация в XML-файл</summary>
        void Dump();
        ///<summary>Десериализация из XML-файла</summary>
        void Load();
        Table ToTable();
        int Compare(int i1, int i2);
    }
}
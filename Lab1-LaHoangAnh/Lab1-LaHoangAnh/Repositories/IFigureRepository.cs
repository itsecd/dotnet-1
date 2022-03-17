using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFigureRepository
    {
        void Add(Figure figure);

        void RemoveAll();

        void RemoveAt(int index);

        List<Figure> GetList();
    }
}
using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repository
{
    public interface IFigureRepository
    {
        void Add(Figure NewFigure);

        void Clear();

        void RemoveAt(int indeX);

        List<Figure> GetFigures();
    }
}
using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFiguresRepository
    {
        void AddFigure(Figure figure);
        void RemoveFigure(int index);
        List<Figure> GetFigures();
    }
}
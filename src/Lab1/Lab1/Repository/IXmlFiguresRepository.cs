using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IXmlFiguresRepository
    {
        void AddFigure(Figure figure);
        void DeleteFigures();
        List<Figure> GetFigures();
        void RemoveFigure(int index);
    }
}
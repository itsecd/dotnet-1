using Lab1.Mode;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IXmlFigureRepository
    {
        void AddFigure(Figure figure);
        bool CompareFigures(int index1, int index2);
        void OuputList();
        void RemoveAllFigure();
        void RemoveFigure(int index);

        List<Figure> GetList();
    }
}
using Lab1.Model;

namespace Lab1.Repositories
{
    public interface IXmlFiguresRepository
    {
        void AddFigure(Figure figure);
        void RemoveFigure(int index);
    }
}
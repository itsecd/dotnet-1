using Lab1.Model;

namespace Lab1.Repositories
{
    public interface IFiguresRepository
    {
        void AddFigure(Figure figure);
        void RemoveFigure(int index);

        void PrintScreen();
    }
}
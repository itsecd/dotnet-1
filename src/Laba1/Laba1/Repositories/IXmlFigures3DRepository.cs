using Laba1.Model;

namespace Laba1.Repositories
{
    public interface IXmlFigures3DRepository
    {
        void AddFigure(Figure3D figure);
        void RemoveFigure(int index);
    }
}
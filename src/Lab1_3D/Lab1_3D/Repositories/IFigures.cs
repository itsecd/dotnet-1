using System.Collections.Generic;
using Lab1_3D.Model;

namespace Lab1_3D.Repositories
{
    public interface IFigures
    {
        void AddFigure(Lab1_3D.Model.Figure3D figure, int index);
        void DeleteFigure(int index);
        List<Lab1_3D.Model.Figure3D> GetFigures();
        void DeleteAllFigures();
        bool CompareFigures(int firstIndex, int secondIndex);
        int GetCountFigures();
        RectangularParallelepiped GetMinFrameParallelepiped(int index);
        double TotalVolume();
        double TotalVolumeWithLinq();
        Figure3D GetFigure(int index);
    }
}
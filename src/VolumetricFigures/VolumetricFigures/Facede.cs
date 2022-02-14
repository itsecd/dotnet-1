using System.Collections.Generic;
using VolumetricFigures.controller;
using VolumetricFigures.model;
using VolumetricFigures.view;

namespace VolumetricFigures
{
    public class Facede
    {
        private List<Counting> _figures;
        private ConsoleController _controller;

        public Facede()
        {
            _figures = new List<Counting>();
            _controller = new ConsoleController(_figures);
        }

        public void Start()
        {
            ConsoleView view = new ConsoleView(_controller);
            view.Run();
        }
    }
}

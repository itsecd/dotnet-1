using Lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Shapes
{
    public class RectangularParallelepiped : Figure
    {
        public Point _vertex{ get; set; }

        public Point _secondVertex { get; set; }

        public RectangularParallelepiped()
        {
            _vertex = new Point();
            _secondVertex = new Point();
        }

        public RectangularParallelepiped(Point vertex, Point secondVertex)
        {
            _vertex = vertex;
            _secondVertex = secondVertex;
        }

        public double GetWidth()
        {
            return Math.Abs(_vertex._x - _secondVertex._x);
        }

        public double GetLength()
        {
            return Math.Abs(_vertex._y - _secondVertex._y);
        }

        public double GetHigth()
        {
            return Math.Abs(_vertex._z - _secondVertex._z);
        }

        public override RectangularParallelepiped GetMinimalFramingParalelepiped()
        {
            return new RectangularParallelepiped(
                new Point(_vertex._x, _vertex._y,_vertex._z),
                new Point(_secondVertex._x, _secondVertex._y, _secondVertex._z)
                );
        }

        public override double GetSurfaceArea()
        {
            return 2 * (GetHigth() * GetWidth() + GetWidth() * GetLength() + GetLength() * GetHigth());
        }

        public override double GetVolume()
        {
            return GetHigth() * GetWidth() * GetLength();
        }

        public override string ToString()
        {
            return "1: " + _vertex + "2: " + _secondVertex;
        }

        public override bool Equals(Object obj) // исправить
        {
            try
            {
                RectangularParallelepiped rectangularCuboid = obj as RectangularParallelepiped;
                return rectangularCuboid._vertex.Equals(_vertex) &&
                rectangularCuboid._secondVertex.Equals(_secondVertex);
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public override int GetHashCode()
        {
            return _vertex.GetHashCode() ^ _secondVertex.GetHashCode();
        }
    }
}

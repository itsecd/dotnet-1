using System;
using Laba1.Model;
using System.Collections.Generic;
using System.Linq;
namespace Laba1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point()
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            List<Figure3D> list = new()
            {
                new RectangularParallelepiped(new Point() { X = 1, Y = 5, Z = 8 }, new Point() { X = 4, Y = 7, Z = 2 }),
                new Sphere(new Point { X = 6, Y = 8, Z = 1 },1.5)
            };
            double sumV = 0;
            foreach(var figure in list)
            {
                sumV += figure.GetV();
            }
            sumV = list.Sum(figure => figure.GetV());
            for(int i = 0; i < list.Count;++i)
            {
                sumV += list[i].GetV();

            }

            Console.WriteLine(sumV);
        }
    }
}

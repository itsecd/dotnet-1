using Lab1.Model;
using System;

namespace Lab1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Figure figure = new Rectangle
            {
                Point1 = new Point(1, 1),
                Point2 = new Point(2, 2)
            };

            Console.WriteLine(figure);
        }
    }
}

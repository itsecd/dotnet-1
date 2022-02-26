using System;
 


namespace PromProg1
{
    internal class Program
    {
        static void Main()
        {
            Figure figure1 = new Rectangle()
            {
                FirstPoint = new Point(1, 2),
                LastPoint = new Point(2, 3)

            };
            Console.WriteLine(figure1.Perimeter());
            Console.WriteLine(figure1.Square());
            Figure figure2 = new Circle()
            {
                Centr = new Point(1, 2),
                Radius = 2

            };
            Console.WriteLine(figure2.Perimeter());
            Console.WriteLine(figure2.Square());
            Figure figure3 = new Triangle(new Point(1,2), new Point(2,3), new Point(3,5));
            Console.WriteLine(figure3.Perimeter());
            Console.WriteLine(figure3.Square());
        }
    }
}

using System;

namespace model
{
    public class Constant : IFunctions
    {
        public int _x;

        public Constant(int x) { _x = x; }  

        public void setX(int x) { _x = x; }
        public int getX() { return _x; }

        public double getResult() { return (double)_x; }

        public void toString()
        {
            Console.WriteLine("y=" + _x);
        }
    }
}
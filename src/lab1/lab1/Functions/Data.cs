using System;


namespace lab1.Functions
{
    public struct Data
    {
        private int _x;
        private int _coeff;
        private int _degree;

        public int X
        {
            get => _x;
            set { _x = value; }
        }
        public int Coeff
        {
            get => _coeff;
            set { _coeff = value; }
        }
        public int Degree
        {
            get => _degree;
            set { _degree = value; }
        }
        public Data(int x = 1, int coeff = 1, int degree=1) { _x = x; _coeff = coeff; _degree = degree; }
    }
}

using System;


namespace PPLab1.Model
{
    public struct Data
    {
        private int _a;
        private int _coeff;

        public int A 
        {
            get => _a;
            set { _a = value; }
        }
        public int Coeff
        {
            get => _coeff;
            set { _coeff = value; }
        }

        public Data(int a = 1, int coeff = 1 ) { _a = a; _coeff = coeff; }

    }
}

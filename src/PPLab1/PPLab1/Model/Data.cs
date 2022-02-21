using System;


namespace PPLab1.Model
{
    internal struct Data
    {
        private int _a;
        private int _k;

        public int A 
        {
            get => _a;
            set { _a = value; }
        }
        public int K
        {
            get => _k;
            set { _k = value; }
        }

        public Data(int a = 1, int k = 1 ) { _a = a; _k = k; }

    }
}

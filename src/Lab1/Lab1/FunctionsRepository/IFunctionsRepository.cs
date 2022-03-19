using Lab1.Model;

namespace Lab1.FunctionsRepository
{
    interface IFunctionsRepository
    {
        Function this[int index]
        {
            get;
            set;
        }
        int Count { get; }
        void Add(Function func);
        void Clear();
        bool Compare(int i, int j);
        public Function GetMaxValueFunction(double x);
        void Delete(int index);
        string ToString();
    }
}
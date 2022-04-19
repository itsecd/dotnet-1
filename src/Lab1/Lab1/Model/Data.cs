namespace Lab1.Model
{
    public struct Data
    {
        public int A { get; set; }
        public int Coeff { get; set; }
        public Data(int a = 1, int coeff = 1) { this.A = a; this.Coeff = coeff; }
    }
}
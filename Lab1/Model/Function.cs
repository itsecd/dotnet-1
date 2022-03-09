namespace Lab1.Model
{
    internal abstract class Function
    {
        /// <summary>
        /// Get Value function with with the specified argument
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public abstract double Compute(double arg);

        public abstract Function GetDerivative();

        public abstract override string ToString();

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    abstract class Function
    {
        /// <summary>
        /// Get Value function with with the specified argument
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public abstract double GetValueFunc(double arg);

        public abstract Function GetDerivative();

        public abstract override string ToString();

        public abstract override bool Equals(object obj);
        
        public abstract override int GetHashCode();
    }
}

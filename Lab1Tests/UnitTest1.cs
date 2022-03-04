using System;
using Xunit;
using Lab1.Matrix;

namespace Lab1Tests
{
    public class MatrixTest
    {
        [Fact]
        public void NormTest()
        {
            var mat1 = new BufferedMatrix(2,2);
            var mat2 = new SparseMatrix(2,2);
            mat1[0,0] = -2;
            mat1[1,1] = 1;
            mat2[0,0] = -2;
            mat2[1,1] = 1;

            Assert.Equal(2, mat1.Norm());
            Assert.Equal(2, mat2.Norm());
            Assert.Equal(2, mat1.NormL());
            Assert.Equal(2, mat2.NormL());
        }

        [Fact]
        public void EqualityTest()
        {
            var mat1 = new BufferedMatrix(2,2);
            var mat2 = new SparseMatrix(2,2);
            var mat3 = new BufferedMatrix(2,2);
        
            Assert.False(mat1.Equals(mat2));
            Assert.True(mat1.Equals(mat3));
        }
    }
}

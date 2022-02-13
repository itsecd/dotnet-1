using System;
using Lab1;
using Xunit;

namespace Lab1Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MatrixEqualityTest()
        {
            BufferedMatrix A = new BufferedMatrix(2, 2);
            BufferedMatrix B = new BufferedMatrix(2, 2);

            Assert.True(A == B);
            A.Set(0, 0, 1.23);
            Assert.True(A != B);
        }

        [Fact]
        public void MatrixNormTest()
        {
            BufferedMatrix A = new BufferedMatrix(2, 2);
            A.Set(0, 0, 1);
            A.Set(0, 1, -2);
            Assert.Equal(2, A.Norm);
        }
    }
}

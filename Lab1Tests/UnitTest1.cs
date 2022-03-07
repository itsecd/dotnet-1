using Xunit;
using Lab1.Matrix;
using System.Xml.Linq;

namespace Lab1Tests
{
    public class MatrixTest
    {
        [Fact]
        public void XmlTest()
        {
            var mat1 = new BufferedMatrix(2,2);
            var mat2 = new SparseMatrix(2,2);
            mat1[0,0] = 1.23;
            mat2[0,0] = 1.23;
            XElement xmat1 = mat1.ToXml();
            XElement xmat2 = mat2.ToXml();
            Assert.Equal(2, int.Parse(xmat1.Attribute("width").Value));
            Assert.Equal(2, int.Parse(xmat1.Attribute("height").Value));
            Assert.Equal(2, int.Parse(xmat2.Attribute("width").Value));
            Assert.Equal(2, int.Parse(xmat2.Attribute("height").Value));

            Assert.Equal(1.23, double.Parse(xmat1.Element("value").Value));
            Assert.Equal(1.23, double.Parse(xmat2.Element("value").Value));
            Assert.Equal(0, double.Parse(xmat2.Element("value").Attribute("i").Value));
            Assert.Equal(0, double.Parse(xmat2.Element("value").Attribute("j").Value));
        }

        [Fact]
        public void StringTest()
        {
            var mat1 = new BufferedMatrix(14,36);
            var mat2 = new SparseMatrix(420, 69);
        
            Assert.Equal("BufferedMatrix [[14x36]]", mat1.ToString());
            Assert.Equal("SparseMatrix [[420x69]]", mat2.ToString());
        }

        [Fact]
        public void AccessTest()
        {
            var mat1 = new BufferedMatrix(2,2);
            var mat2 = new SparseMatrix(2,2);

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    mat1[i,j] = 1;
                    mat2[i,j] = 2;
                    Assert.Equal(1, mat1[i, j]);
                    Assert.Equal(2, mat2[i, j]);
                }
            Assert.Equal(2, mat1.Height);
            Assert.Equal(2, mat1.Width);
            Assert.Equal(2, mat2.Height);
            Assert.Equal(2, mat2.Width);
        }

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

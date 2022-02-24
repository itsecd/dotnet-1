using System.Text;
using System.Xml;

namespace iProg1.Model
{
    public static class Helper
    {
        public static bool IsValidIndex(int index, int maxIndex)
        {
            return index < maxIndex;
        }
        
        public static void SkipToElement(XmlTextReader reader)
        {
            while (reader.NodeType != XmlNodeType.Element)
            {
                reader.Read();
            }
        }
        
        public static string GetCurrentElemsOfMatrix(double[][] array, int indI, int indJ)
        {
            var str = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length; j++)
                {
                    if (i == indI && j == indJ)
                    {
                        return str.ToString();
                    }
                    else
                    {
                        str.Append(array[i][j]);
                        str.Append(" ");
                    }
                }
                str.Append('\n');
            }
            return str.ToString();
        }
    }
}

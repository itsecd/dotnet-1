using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1.Repository
{
    public class XmlMatricesRepository : IMatricesRepository
    {
        private const string StorageFileName = "matrices.xml";
        private List<Matrix> _matrices;

        public XmlMatricesRepository()
        {
            _matrices = new List<Matrix>();
        }
        private void ReadFromFile()
        {
            if (_matrices != null) return;

            if (!File.Exists(StorageFileName))
            {
                _matrices = new List<Matrix>();
                return;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Matrix>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _matrices = (List<Matrix>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Matrix>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _matrices);
        }

        public void AddMatrix(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            ReadFromFile();
            _matrices.Add(matrix);
            WriteToFile();
        }

        private void RemoveMatrix(int index)
        {
            ReadFromFile();
            _matrices.RemoveAt(index);
            WriteToFile();
        }
    }
}

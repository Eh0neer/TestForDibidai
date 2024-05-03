using System.IO;
using CsvHelper;
using CsvHelper.Configuration;


namespace TestForDibiai.Services
{
    public class CsvService
    {
        public void ExportToCsv<T>(List<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(data);
            }
        }
    }
}

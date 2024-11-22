using CsvHelper;
using CsvHelper.Configuration;
using CurrencyExchangePatternExplorer.Model;
using System.Globalization;

namespace CurrencyExchangePatternExplorer.Helpers
{
    internal class FileReader
    {
        public IEnumerable<CurrencyRate> ReadFile(string filePath)
        {
            using var reader = File.OpenRead(filePath);
            using var file = new StreamReader(reader);
            using var csvReader = new CsvReader(file,
                new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ","
                });

            csvReader.Read();

            while (csvReader.Read())
            {
                yield return Factory(csvReader);
            }
        }

        private CurrencyRate Factory(CsvReader csvReader)
        {
            return new CurrencyRate()
            {
                Date = csvReader.GetField<DateTime>(0),
                Rate = csvReader.GetField<double>(1)
            };
        }
    }
}

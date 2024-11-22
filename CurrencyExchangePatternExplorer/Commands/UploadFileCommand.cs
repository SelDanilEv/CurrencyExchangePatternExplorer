using CurrencyExchangePatternExplorer.Helpers;
using CurrencyExchangePatternExplorer.Model;

namespace CurrencyExchangePatternExplorer.Commands
{
    internal static class UploadFileCommand
    {
        public static void Run(CurrencyExchangeModel model, bool isDefault = false)
        {
            model.CurrencyRates = new List<CurrencyRate>();

            string? filePath;
            if (!isDefault)
            {
                Console.WriteLine("Import file path with name");

                filePath = Console.ReadLine();
            }
            else
            {
                filePath = "C:\\Users\\HP\\Downloads\\EUR_USD.csv";
            }


            try
            {
                var fileReader = new FileReader();

                foreach (var rate in fileReader.ReadFile(filePath))
                {
                    model.CurrencyRates.Add(rate);
                }
                if (!isDefault)
                {
                    Console.WriteLine("Import finished");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Import failed");
            }
        }
    }
}

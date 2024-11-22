namespace CurrencyExchangePatternExplorer.Model
{
    internal class CurrencyExchangeModel
    {
        public CurrencyExchangeModel()
        {
            Models = new List<BaseBehaviorModel>
            {
                new BuyEach30DaysModel(),
                new BuyEach7DayModel(),
                new BuyEach7Day50_50Model(),
                new BuyEach7Day75_25Model(),
                new BuyEach7Day25_75Model(),
                new BuyEachDayModel(),
            };
        }

        public List<CurrencyRate> CurrencyRates { get; set; }
            = new List<CurrencyRate>();

        public List<BaseBehaviorModel> Models { get; set; }

        public void RunAll()
        {
            Models.ForEach(x =>
            {
                x.Reset();
                x.SetRatesInfo(CurrencyRates);
                x.Run();
            }
            );
        }

        public void PrintAll()
        {
            Models.ForEach(x => x.PrintResult());
        }

    }
}

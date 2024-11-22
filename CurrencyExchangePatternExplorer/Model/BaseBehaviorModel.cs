namespace CurrencyExchangePatternExplorer.Model
{
    internal class BaseBehaviorModel
    {
        private double _spendAmount { get; set; } = 0;
        private double _receivedAmount { get; set; } = 0;
        private double _averageRate =>
            _receivedAmount / (_spendAmount == 0 ? 1 : _spendAmount);

        private readonly string _name;


        protected List<CurrencyRate> CurrencyRates = new List<CurrencyRate>();
        protected double DailyMoney = 7 * 4;
        protected double Balance { get; set; } = 0;
        protected DateTime? StartDate => CurrencyRates.MinBy(x => x.Date).Date;
        protected DateTime CurrentDate { get; set; }
        protected DateTime? EndDate => CurrencyRates.MaxBy(x => x.Date).Date;
        protected double GetTodayRate() => GetRateByDate(CurrentDate);
        protected double GetRateByDate(DateTime date)
        {
            CurrencyRate rate = null;
            while (rate == null)
            {
                rate = CurrencyRates.FirstOrDefault(x => x.Date == date);

                date = date.AddDays(-1);
            };


            return rate.Rate;
        }

        protected void MakeTransaction(double amount, double rate)
        {
            if (Balance - amount < 0)
                amount = Balance;

            Balance -= amount;
            _spendAmount += amount;
            _receivedAmount += amount * rate;
        }


        public BaseBehaviorModel(string name)
        {
            _name = name;
        }

        public void Reset()
        {
            _spendAmount = 0;
            _receivedAmount = 0;
        }

        public void SetRatesInfo(List<CurrencyRate> currencyRates)
        {
            CurrencyRates = currencyRates;
        }

        public void Run()
        {
            CurrentDate = StartDate.Value;

            while (CurrentDate < EndDate)
            {
                Balance += DailyMoney;

                NewDay();

                CurrentDate = CurrentDate.AddDays(1);
            }

            MakeTransaction(Balance, GetTodayRate());
        }

        protected virtual void NewDay()
        {

        }

        public void PrintResult()
        {
            Console.WriteLine($"-------------");
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Spend: {_spendAmount}");
            Console.WriteLine($"Received: {_receivedAmount}");
            Console.WriteLine($"Average rate: {_averageRate}");
            Console.WriteLine($"-------------");
        }
    }
}

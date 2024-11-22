
namespace CurrencyExchangePatternExplorer.Model
{
    internal class BuyEach7Day25_75Model : BaseBehaviorModel
    {
        public BuyEach7Day25_75Model() : base("Buy each 7 days (2.5/7.5)")
        {
        }

        private int DayCounter = 1;

        private List<(double rate, double amount, DateTime date)> Applications =
            new List<(double rate, double amount, DateTime date)>();

        private double GetBestRateFor7Days()
        {
            return CurrencyRates
                .Where(x => x.Date <= CurrentDate
                    && x.Date > CurrentDate.AddDays(-7))
                .MaxBy(x => x.Rate)
                .Rate;
        }

        private void CheckApplications()
        {
            var validApplications =
                Applications
                .Where(x => x.rate <= GetBestRateFor7Days())
                .ToList();

            validApplications.ForEach(x => MakeTransaction(x.amount, x.rate));

            Applications = Applications.Except(validApplications).ToList();
        }

        protected override void NewDay()
        {
            if (DayCounter % 7 == 0)
            {
                CheckApplications();

                if (GetTodayRate() < GetBestRateFor7Days())
                {
                    MakeTransaction(DailyMoney * 7 * 0.25, GetTodayRate());
                    Applications.Add(
                        (GetBestRateFor7Days(),
                        DailyMoney * 7 * 0.75,
                        CurrentDate));
                }
                else
                {
                    MakeTransaction(DailyMoney * 7, GetTodayRate());
                }

                DayCounter = 0;
            }
            DayCounter++;
        }

    }
}

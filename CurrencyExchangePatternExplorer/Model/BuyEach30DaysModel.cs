
namespace CurrencyExchangePatternExplorer.Model
{
    internal class BuyEach30DaysModel : BaseBehaviorModel
    {
        public BuyEach30DaysModel() : base("Buy each 30 days")
        {
        }

        private int DayCounter = 1;

        protected override void NewDay()
        {
            if (DayCounter % 30 == 0)
            {
                MakeTransaction(Balance, GetTodayRate());
                DayCounter = 0;
            }
            DayCounter++;
        }

    }
}


namespace CurrencyExchangePatternExplorer.Model
{
    internal class BuyEach7DayModel : BaseBehaviorModel
    {
        public BuyEach7DayModel() : base("Buy each 7 days")
        {
        }

        private int DayCounter = 1;

        protected override void NewDay()
        {
            if (DayCounter % 7 == 0)
            {
                MakeTransaction(Balance, GetTodayRate());
                DayCounter = 0;
            }
            DayCounter++;
        }

    }
}

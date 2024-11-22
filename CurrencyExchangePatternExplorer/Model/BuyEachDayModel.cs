
namespace CurrencyExchangePatternExplorer.Model
{
    internal class BuyEachDayModel : BaseBehaviorModel
    {
        public BuyEachDayModel() : base("Buy each day")
        {
        }

        protected override void NewDay()
        {
            MakeTransaction(DailyMoney, GetTodayRate());
        }

    }
}

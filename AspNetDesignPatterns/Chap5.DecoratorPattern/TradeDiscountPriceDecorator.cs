namespace Chap5.DecoratorPattern
{
    public class TradeDiscountPriceDecorator:IPrice
    {
        private IPrice _basePrice;

        public TradeDiscountPriceDecorator(IPrice basePrice)
        {
            _basePrice = basePrice;
        }

        public decimal Cost
        {
            get{ return _basePrice.Cost*0.95m; }
            set { _basePrice.Cost = value; }
        }
    }
}
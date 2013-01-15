namespace Chap5.DecoratorPattern
{
    public class CurrencyPriceDecorator:IPrice
    {
        private IPrice _basePrice;
        private decimal _exchangeRate;

        public CurrencyPriceDecorator(IPrice basePrice, decimal exchangeRate)
        {
            _basePrice = basePrice;
            _exchangeRate = exchangeRate;
        }



        public decimal Cost { get { return _basePrice.Cost*_exchangeRate; } set; }
    }
}
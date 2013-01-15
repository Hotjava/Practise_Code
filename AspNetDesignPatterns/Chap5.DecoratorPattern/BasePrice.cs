namespace Chap5.DecoratorPattern
{
    public class BasePrice:IPrice
    {
        private decimal _cost;
        public decimal Cost
        {
            get { return _cost; } 
            set { _cost = value; }
        }
    }
}
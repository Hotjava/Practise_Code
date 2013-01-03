using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class Price
    {
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _rrp;
        private decimal _sellingPrice;


        public Price(decimal rrp, decimal sellingPrice)
        {
            _rrp = rrp;
            _sellingPrice = sellingPrice;
        }

        public void SetDiscountStrategyTo(IDiscountStrategy discountStrategy)
        {
            this._discountStrategy = discountStrategy;
        }

        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountTo(_sellingPrice); }
        }

        public  decimal RRP
        {
            get { return _rrp; }
        }

        public decimal Discount
        {
            get { return RRP > SellingPrice ? RRP - SellingPrice : 0; }
        }
        
        public decimal Savings
        {
            get { return RRP > SellingPrice ? 1 - (SellingPrice/RRP) : 0; }
        }
    }
}

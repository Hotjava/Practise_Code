using System.Collections.Generic;

namespace Chap5.DecoratorPattern
{
    public static class ProductCollectionExtesionMethods
    {
        public static void ApplyCurrencyDiscount(this IEnumerable<Product> products)
        {
             foreach (Product p in products)
            {
               p.price = new CurrencyPriceDecorator(p.price, 0.7m);
            }
        }

        public static void ApplyTradDiscount(this IEnumerable<Product> prouducts)
        {
            foreach (var product in prouducts)
            {
                product.price = new TradeDiscountPriceDecorator(product.price);
            }
        }
    }
}
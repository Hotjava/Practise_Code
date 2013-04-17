using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product proudct, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(p => p.Product.ProductID == proudct.ProductID);
            if (line == null)
            {
                lineCollection.Add(new CartLine() {Product =proudct, Quantity =quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product p)
        {
            lineCollection.RemoveAll(line => line.Product.ProductID == p.ProductID);
        }

        public decimal computeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price*e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        } 

    }

    public class CartLine
    {
        public  Product Product { get; set; }
        public int  Quantity { get; set; }
    }
}

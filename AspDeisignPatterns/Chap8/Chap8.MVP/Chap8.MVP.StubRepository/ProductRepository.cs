﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap8.MVP.Model;

namespace Chap8.MVP.StubRepository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> FindAll()
        {
            return new DataContext().Products;
        }

        public Product FindBy(int Id)
        {
            Product productFound = new DataContext()
                .Products.FirstOrDefault(prod => prod.Id == Id);
            if (productFound != null)
            {
                productFound.Description =
                    "orem ipsum dolor sit amet, consectetur adipiscing elit." +
                    "Praesent est libero, imperdiet eget dapibusvel, tempus." +
                    "Nullam eu metus justo." +
                    "Curabitur sit amet lectus lorem, a tempus felis. " +
                    "Phasellus consectetur eleifend est, euismodcursus tellus.";
            }
            return productFound;
        }
    }
}
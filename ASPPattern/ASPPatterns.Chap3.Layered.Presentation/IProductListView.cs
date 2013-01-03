﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public  interface IProductListView
    {
         void Dispaly(IList<ProductViewModel> products);
         Model.CustomerType CustomerType { get; }
         string ErrorMessage { set; }
    }
}

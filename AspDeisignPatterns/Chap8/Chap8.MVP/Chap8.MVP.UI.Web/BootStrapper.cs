using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chap8.MVP.Model;
using Chap8.MVP.Presentation.Basket;
using Chap8.MVP.Presentation.Navigation;
using Chap8.MVP.StubRepository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Chap8.MVP.UI.Web
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x=> x.AddRegistry<ControllerRegistry>());
        }
    }

    public class ControllerRegistry:Registry 
    {
        public ControllerRegistry()
        {
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IProductRepository>().Use<ProductRepository>();
            For<IPageNavigator>().Use<PageNavigator>();
            For<IBasket>().Use<Basket>();
        }
    }
}
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository 
    {
        private EFDbContext context= new EFDbContext();
        #region Implementation of IProductRepository

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public IQueryable<Category> Categories
        {
            get
            {
                var c = from p in Products
                        select new Category {Name = p.Category};
                 return c.Distinct();
            }
        }

        public void SaveProduct(Product p)
        {
            if (p.ProductID == 0)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();



        }

        #endregion
    }
}
using System.Collections.Generic;
using System.Linq;
using Chap8.MVP.Model;

namespace Chap8.MVP.StubRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> FindAll()
        {
            return new DataContext().Categories;
        }
        public Category FindBy(int Id)
        {
            return new DataContext().Categories.FirstOrDefault(cat => cat.Id == Id);
        }
    }
}
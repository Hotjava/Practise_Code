using System.Collections.Generic;

namespace Chap8.MVP.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();
        Category FindBy(int Id);
    }
}
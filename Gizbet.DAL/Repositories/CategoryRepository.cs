using System.Data.Entity;
using Gizbet.DAL.Entities;

namespace Gizbet.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}

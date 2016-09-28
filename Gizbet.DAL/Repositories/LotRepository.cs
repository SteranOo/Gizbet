using System.Data.Entity;
using Gizbet.DAL.Entities;

namespace Gizbet.DAL.Repositories
{
    public class LotRepository : GenericRepository<Lot>
    {
        public LotRepository(DbContext context) : base(context) { }
    }
}

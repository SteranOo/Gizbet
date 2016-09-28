using System.Data.Entity;
using Gizbet.DAL.Entities;

namespace Gizbet.DAL.Repositories
{
    class BidRepository : GenericRepository<Bid>
    {
        public BidRepository(DbContext context) : base(context) { }
    }
}

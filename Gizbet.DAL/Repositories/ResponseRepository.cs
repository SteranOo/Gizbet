using System.Data.Entity;
using Gizbet.DAL.Entities;

namespace Gizbet.DAL.Repositories
{
    class ResponseRepository : GenericRepository<Response>
    {
        public ResponseRepository(DbContext context) : base(context) { }
    }
}

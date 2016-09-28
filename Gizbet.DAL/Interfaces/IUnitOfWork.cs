using System;
using System.Threading.Tasks;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Identity;

namespace Gizbet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IGenericRepository<Bid> BidRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Lot> LotRepository { get; }
        IGenericRepository<Response> ResponseRepository { get; }
    
        Task SaveAsync();
    }
}

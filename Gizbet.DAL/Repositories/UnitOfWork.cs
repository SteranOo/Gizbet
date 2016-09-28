using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Gizbet.DAL.EF;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Entities.Identity;
using Gizbet.DAL.Identity;
using Gizbet.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gizbet.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IGenericRepository<Bid> BidRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Lot> LotRepository { get; }
        public IGenericRepository<Response> ResponseRepository { get; }

        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContext();

            UserManager = new ApplicationUserManager(
                    new UserStore<ApplicationUser,
                    ApplicationRole,
                    int, ApplicationUserLogin,
                    ApplicationUserRole,
                    ApplicationUserClaim>(_dbContext));

            RoleManager = new ApplicationRoleManager(
                    new RoleStore<ApplicationRole, int, ApplicationUserRole>(_dbContext));

            BidRepository = new BidRepository(_dbContext);
            LotRepository = new LotRepository(_dbContext);
            ResponseRepository = new ResponseRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
        }

        public async Task SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _isDisposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    _dbContext.Dispose();
                }
                _isDisposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}

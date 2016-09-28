using Gizbet.DAL.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace Gizbet.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store) : base(store) { }
    }
}

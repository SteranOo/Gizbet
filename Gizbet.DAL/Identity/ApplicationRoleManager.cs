using Gizbet.DAL.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace Gizbet.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store) : base(store) { }
    }
}

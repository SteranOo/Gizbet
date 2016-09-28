using System.Security.Claims;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Infrastructure;

namespace Gizbet.BLL.Interfaces
{
    public interface IUserService : IService
    {
        Task<ApplicationUserDTO> GetUserByUserNameAsync(string userName);

        Task<OperationDetails> CreateAsync(ApplicationUserDTO userDto);
        Task<ClaimsIdentity> AuthenticateAsync(ApplicationUserDTO userDto);
    }
}

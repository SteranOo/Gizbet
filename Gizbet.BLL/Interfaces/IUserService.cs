using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Infrastructure;

namespace Gizbet.BLL.Interfaces
{
    /// <summary>
    /// Service provides methods for working with application users 
    /// </summary>
    public interface IUserService : IService
    {
        /// <summary>
        /// Returns user by username
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>ApplicationUserDTO object</returns>
        Task<ApplicationUserDTO> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>List of ApplicationUserDTO objects</returns>
        Task<List<ApplicationUserDTO>> GetAllAsync();

        /// <summary>
        /// Returns is user banned
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>Bool value</returns>
        Task<bool> IsBannedAsync(string userName);

        /// <summary>
        /// Ban user by username
        /// </summary>
        /// <param name="userName">Username</param>
        Task BanUserAsync(string userName);

        /// <summary>
        /// Unban user by username
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns></returns>
        Task UnBanUserAsync(string userName);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userDto">UserDTO object</param>
        /// <returns>OperationDetails object</returns>
        Task<OperationDetails> CreateAsync(ApplicationUserDTO userDto);

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userDto">UserDTO object</param>
        /// <returns></returns>
        Task<ClaimsIdentity> AuthenticateAsync(ApplicationUserDTO userDto);
    }
}

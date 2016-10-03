using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    /// <summary>
    /// Service provides methods for working with lots 
    /// </summary>
    public interface ILotService : IService
    {
        /// <summary>
        /// Get lot by id
        /// </summary>
        /// <param name="id">Lot id</param>
        /// <returns>LotDTO object</returns>
        Task<LotDTO> GetAsync(int id);

        /// <summary>
        /// Get all lots
        /// </summary>
        /// <returns>List of LotDTO objects</returns>
        Task<List<LotDTO>> GetAllAsync();

        /// <summary>
        /// Get lots by predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of LotDTO objects</returns>
        Task<List<LotDTO>> FindByAsync(Expression<Func<LotDTO, bool>> predicate);

        /// <summary>
        /// Add lot
        /// </summary>
        /// <param name="lotDTO">LotDTO object</param>
        /// <returns>Added LotDTO object</returns>
        Task<LotDTO> AddAsync(LotDTO lotDTO);

        /// <summary>
        /// Edit lot
        /// </summary>
        /// <param name="lotDTO">LotDTO object</param>
        /// <returns>Edited LotDTO object</returns>
        Task EditAsync(LotDTO lotDTO);

        /// <summary>
        /// Delete lot
        /// </summary>
        /// <param name="lotDTO">LotDTO object</param>
        /// <returns>Deleted LotDTO object</returns>
        Task<LotDTO> DeleteAsync(LotDTO lotDTO);

        /// <summary>
        /// Delete lot by id
        /// </summary>
        /// <param name="lotId">Lot id object</param>
        /// <returns>Deleted LotDTO object</returns>
        Task<LotDTO> DeleteLotByIdAsync(int lotId);

        /// <summary>
        /// Returns not sold lots
        /// </summary>
        /// <returns>List of LotDTO objects</returns>
        Task<List<LotDTO>> GetActiveLotsAsync();
       
        /// <summary>
        /// Add bid to lot
        /// </summary>
        /// <param name="lotId">Lot id</param>
        /// <param name="userId">User id</param>
        /// <returns>LotDTO object</returns>
        Task<LotDTO> MakeBidAsync(int lotId, int userId);

        /// <summary>
        /// Add bid to lot and change it's state to sold 
        /// </summary>
        /// <param name="lotId">Lot id</param>
        /// <param name="userId">User id</param>
        /// <returns>LotDTO object</returns>
        Task<LotDTO> BuyLotAsync(int lotId, int userId);
    }
}

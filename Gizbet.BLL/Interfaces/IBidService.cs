using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    /// <summary>
    /// Service provides methods for working with bids 
    /// </summary>
    public interface IBidService : IService
    {
        /// <summary>
        /// Get bid by id
        /// </summary>
        /// <param name="id">Bid id</param>
        /// <returns>BidDTO object</returns>
        Task<BidDTO> GetAsync(int id);

        /// <summary>
        /// Get all bids
        /// </summary>
        /// <returns>List of BidDTO objects</returns>
        Task<List<BidDTO>> GetAllAsync();

        /// <summary>
        /// Get bids by predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of BidDTO objects</returns>
        Task<List<BidDTO>> FindByAsync(Expression<Func<BidDTO, bool>> predicate);

        /// <summary>
        /// Add bid
        /// </summary>
        /// <param name="bidDTO">BidDTO object</param>
        /// <returns>Added BidDTO object</returns>
        Task<BidDTO> AddAsync(BidDTO bidDTO);

        /// <summary>
        /// Edit bid
        /// </summary>
        /// <param name="bidDTO">BidDTO object</param>
        /// <returns>Edited BidDTO object</returns>
        Task EditAsync(BidDTO bidDTO);

        /// <summary>
        /// Delete bid
        /// </summary>
        /// <param name="bidDTO">BidDTO object</param>
        /// <returns>Deleted BidDTO object</returns>
        Task<BidDTO> DeleteAsync(BidDTO bidDTO);
    }
}

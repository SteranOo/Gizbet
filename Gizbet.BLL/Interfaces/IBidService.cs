using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    public interface IBidService : IService
    {
        Task<BidDTO> GetAsync(int id);
        Task<List<BidDTO>> GetAllAsync();
        Task<List<BidDTO>> FindByAsync(Expression<Func<BidDTO, bool>> predicate);
        Task<BidDTO> AddAsync(BidDTO bidDTO);
        Task EditAsync(BidDTO bidDTO);
        Task<BidDTO> DeleteAsync(BidDTO bidDTO);
    }
}

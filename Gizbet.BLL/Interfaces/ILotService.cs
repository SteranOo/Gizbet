using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    public interface ILotService : IService
    {
        Task<LotDTO> GetAsync(int id);
        Task<List<LotDTO>> GetAllAsync();
        Task<List<LotDTO>> FindByAsync(Expression<Func<LotDTO, bool>> predicate);
        Task<LotDTO> AddAsync(LotDTO lotDTO);
        Task EditAsync(LotDTO lotDTO);
        Task<LotDTO> DeleteAsync(LotDTO lotDTO);
        Task<LotDTO> DeleteLotByIdAsync(int lotId);
        Task<List<LotDTO>> GetActiveLotsAsync();
        Task<List<LotDTO>> GetActiveLotsByCategoryAsync(int categoryId);
        Task<LotDTO> MakeBidAsync(int lotId, int userId);
        Task<LotDTO> BuyLotAsync(int lotId, int userId);
    }
}

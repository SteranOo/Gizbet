using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    public interface ICategoryService : IService
    {
        Task<CategoryDTO> GetAsync(int id);
        Task<List<CategoryDTO>> GetAllAsync();
        Task<List<CategoryDTO>> FindByAsync(Expression<Func<CategoryDTO, bool>> predicate);
        Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO);
        Task EditAsync(CategoryDTO categoryDTO);
        Task<CategoryDTO> DeleteAsync(CategoryDTO categoryDTO);
    }
}

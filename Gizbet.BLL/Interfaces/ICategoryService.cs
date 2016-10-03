using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gizbet.BLL.DTO;

namespace Gizbet.BLL.Interfaces
{
    /// <summary>
    /// Service provides methods for working with categories 
    /// </summary>
    public interface ICategoryService : IService
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>CategoryDTO object</returns>
        Task<CategoryDTO> GetAsync(int id);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of CategoryDTO objects</returns>
        Task<List<CategoryDTO>> GetAllAsync();

        /// <summary>
        /// Get categories by predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of CategoryDTO objects</returns>
        Task<List<CategoryDTO>> FindByAsync(Expression<Func<CategoryDTO, bool>> predicate);

        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="categoryDTO">CategoryDTO object</param>
        /// <returns>Added CategoryDTO object</returns>
        Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO);

        /// <summary>
        /// Edit category
        /// </summary>
        /// <param name="categoryDTO">CategoryDTO object</param>
        /// <returns>Edited CategoryDTO object</returns>
        Task EditAsync(CategoryDTO categoryDTO);

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="categoryDTO">CategoryDTO object</param>
        /// <returns>Deleted CategoryDTO object</returns>
        Task<CategoryDTO> DeleteAsync(CategoryDTO categoryDTO);
    }
}

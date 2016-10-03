using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Infrastructure;
using Gizbet.BLL.Interfaces;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Interfaces;
using static Gizbet.BLL.Configuration.AutoMapperConfigurationBLL;

namespace Gizbet.BLL.Services
{
    public class CategoryService : GeneralService, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = GetMapper();
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.CategoryRepository.Get(id));
                return _mapper.Map<CategoryDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.CategoryRepository.GetAll().ToList());
                return _mapper.Map<List<CategoryDTO>>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<List<CategoryDTO>> FindByAsync(Expression<Func<CategoryDTO, bool>> predicate)
        {
            try
            {
                var exp = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
                var res = await Task.Run(() => _unitOfWork.CategoryRepository.FindBy(exp).ToList());
                return _mapper.Map<List<CategoryDTO>>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.CategoryRepository.Add(_mapper.Map<Category>(categoryDTO)));
                await _unitOfWork.SaveAsync();
                return _mapper.Map<CategoryDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task EditAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var category = await Task.Run(() => _unitOfWork.CategoryRepository.Get(categoryDTO.Id));
                _mapper.Map(categoryDTO, category);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<CategoryDTO> DeleteAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var category = await Task.Run(() => _unitOfWork.CategoryRepository.Get(categoryDTO.Id));
                var res = await Task.Run(() => _unitOfWork.CategoryRepository.Delete(category));
                await _unitOfWork.SaveAsync();
                return _mapper.Map<CategoryDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }
    }
}

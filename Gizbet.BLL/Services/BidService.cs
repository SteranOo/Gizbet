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
    public class BidService : GeneralService, IBidService
    {
        private readonly IMapper _mapper;

        public BidService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = GetMapper();
        }

        public async Task<BidDTO> GetAsync(int id)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.BidRepository.Get(id));
                return _mapper.Map<BidDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }

        }

        public async Task<List<BidDTO>> GetAllAsync()
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.BidRepository.GetAll().ToList());
                return _mapper.Map<List<BidDTO>>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<List<BidDTO>> FindByAsync(Expression<Func<BidDTO, bool>> predicate)
        {
            try
            {
                var exp = _mapper.Map<Expression<Func<Bid, bool>>>(predicate);
                var res = await Task.Run(() => _unitOfWork.BidRepository.FindBy(exp).ToList());
                return _mapper.Map<List<BidDTO>>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<BidDTO> AddAsync(BidDTO bidDTO)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.BidRepository.Add(_mapper.Map<Bid>(bidDTO)));
                await _unitOfWork.SaveAsync();
                return _mapper.Map<BidDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task EditAsync(BidDTO bidDTO)
        {
            try
            {
                var bid = await Task.Run(() => _unitOfWork.BidRepository.Get(bidDTO.Id));
                _mapper.Map(bidDTO, bid);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<BidDTO> DeleteAsync(BidDTO bidDTO)
        {
            try
            {
                var bid = await Task.Run(() => _unitOfWork.BidRepository.Get(bidDTO.Id));
                var res = await Task.Run(() => _unitOfWork.BidRepository.Delete(bid));
                await _unitOfWork.SaveAsync();
                return _mapper.Map<BidDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<bool> IsBanned(int userId)
        {
            try
            {
                return await _unitOfWork.UserManager.IsLockedOutAsync(userId);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }
    }
}

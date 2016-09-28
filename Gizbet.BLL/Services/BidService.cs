using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Gizbet.BLL.DTO;
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
            var res = await Task.Run(() => _unitOfWork.BidRepository.Get(id));
            return _mapper.Map<BidDTO>(res);
        }

        public async Task<List<BidDTO>> GetAllAsync()
        {
            var res = await Task.Run(() => _unitOfWork.BidRepository.GetAll().ToList());
            return _mapper.Map<List<BidDTO>>(res);
        }

        public async Task<List<BidDTO>> FindByAsync(Expression<Func<BidDTO, bool>> predicate)
        {
            var exp = _mapper.Map<Expression<Func<Bid, bool>>>(predicate);
            var res = await Task.Run(() => _unitOfWork.BidRepository.FindBy(exp).ToList());
            return _mapper.Map<List<BidDTO>>(res);
        }

        public async Task<BidDTO> AddAsync(BidDTO bidDTO)
        {
            var res = await Task.Run(() => _unitOfWork.BidRepository.Add(_mapper.Map<Bid>(bidDTO)));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BidDTO>(res);
        }

        public async Task EditAsync(BidDTO bidDTO)
        {
            var bid = _unitOfWork.BidRepository.Get(bidDTO.Id);
            _mapper.Map(bidDTO, bid);
            await _unitOfWork.SaveAsync();
        }

        public async Task<BidDTO> DeleteAsync(BidDTO bidDTO)
        {
            var bid = _unitOfWork.BidRepository.Get(bidDTO.Id);
            var res = await Task.Run(() => _unitOfWork.BidRepository.Delete(bid));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BidDTO>(res);
        }
    }
}

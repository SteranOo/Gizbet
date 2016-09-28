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
    public class LotService : GeneralService, ILotService
    {
        private IMapper _mapper;

        public LotService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = GetMapper();
        }

        public async Task<LotDTO> GetAsync(int id)
        {
            var lot = await Task.Run(() => _unitOfWork.LotRepository.Get(id));
            var lotDTO = _mapper.Map<LotDTO>(lot);
            return lotDTO;
        }

        public async Task<List<LotDTO>> GetAllAsync()
        {
            var lots = await Task.Run(() => _unitOfWork.LotRepository.GetAll().ToList());
            var lotDTOs = _mapper.Map<List<LotDTO>>(lots);
            return lotDTOs;
        }

        public async Task<List<LotDTO>> FindByAsync(Expression<Func<LotDTO, bool>> predicate)
        {
            var exp = _mapper.Map<Expression<Func<Lot, bool>>>(predicate);
            var lots = await Task.Run(() => _unitOfWork.LotRepository.FindBy(exp).ToList());
            var lotDTOs = _mapper.Map<List<LotDTO>>(lots);
            return lotDTOs;
        }

        public async Task<LotDTO> AddAsync(LotDTO lotDTO)
        {
            var res = await Task.Run(() => _unitOfWork.LotRepository.Add(_mapper.Map<Lot>(lotDTO)));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LotDTO>(res);
        }

        public async Task EditAsync(LotDTO lotDTO)
        {
            var lot = _unitOfWork.LotRepository.Get(lotDTO.Id);
            _mapper.Map(lotDTO, lot);
            await _unitOfWork.SaveAsync();
        }

        public async Task<LotDTO> DeleteAsync(LotDTO lotDTO)
        {
            var lot = _unitOfWork.LotRepository.Get(lotDTO.Id);
            var res = await Task.Run(() => _unitOfWork.LotRepository.Delete(lot));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LotDTO>(res);
        }

        public async Task<LotDTO> DeleteLotByIdAsync(int lotId)
        {
            var lot = _unitOfWork.LotRepository.Get(lotId);
            var res = await Task.Run(() => _unitOfWork.LotRepository.Delete(lot));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LotDTO>(res);
        }

        public async Task<LotDTO> MakeBidAsync(int lotId, int userId)
        {
            var lot = await Task.Run(() => _unitOfWork.LotRepository.Get(lotId));
            var topBid = lot.Bids.OrderByDescending(b => b.Amount).FirstOrDefault();
            await Task.Run(() => _unitOfWork.BidRepository.Add(new Bid
            {
                Amount = (topBid?.Amount ?? lot.InitialPrice) + lot.Step,
                LotId = lotId,
                ApplicationUserId = userId,
                TimeOfBid = DateTime.Now
            }));
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LotDTO>(lot);
        }
    
        public async Task<LotDTO> BuyLotAsync(int lotId, int userId)
        {
            var lot = await Task.Run(() => _unitOfWork.LotRepository.Get(lotId));
            await Task.Run(() => _unitOfWork.BidRepository.Add(new Bid
            {
                Amount = lot.SellingPrice ?? 0,
                LotId = lotId,
                ApplicationUserId = userId,
                TimeOfBid = DateTime.Now
            }));
            lot.IsSold = true;
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LotDTO>(lot);
        }

        public async Task<List<LotDTO>> GetActiveLotsAsync()
        {
            var lots = await Task.Run(() => _unitOfWork.LotRepository.FindBy(l => !l.IsSold).ToList());
            var lotDTOs = _mapper.Map<List<LotDTO>>(lots);
            return lotDTOs;
        }

        public async Task<List<LotDTO>> GetActiveLotsByCategoryAsync(int categoryId)
        {
            var lots = await Task.Run(() => _unitOfWork.LotRepository
                .FindBy(l => !l.IsSold && l.CategoryId == categoryId).ToList());
          
            var lotDTOs = _mapper.Map<List<LotDTO>>(lots);
            return lotDTOs;
        }
    }
}




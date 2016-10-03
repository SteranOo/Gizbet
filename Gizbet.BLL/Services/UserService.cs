using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Infrastructure;
using Gizbet.BLL.Interfaces;
using Gizbet.DAL.Entities.Identity;
using Gizbet.DAL.Interfaces;
using static Gizbet.BLL.Configuration.AutoMapperConfigurationBLL;

namespace Gizbet.BLL.Services
{
    public class UserService : GeneralService, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = GetMapper();
        }

        public async Task<List<ApplicationUserDTO>> GetAllAsync()
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.UserManager.Users.Where(u => u.LockoutEnabled).ToList());
                return _mapper.Map<List<ApplicationUserDTO>>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<bool> IsBannedAsync(string userName)
        {
            try
            {
                var user = await Task.Run(() => _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(userName)));
                return await _unitOfWork.UserManager.IsLockedOutAsync(user.Id);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<ApplicationUserDTO> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(userName)));
                return _mapper.Map<ApplicationUserDTO>(res);
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task BanUserAsync(string userName)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(userName)));
                await _unitOfWork.UserManager.SetLockoutEndDateAsync(res.Id, DateTimeOffset.MaxValue);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task UnBanUserAsync(string userName)
        {
            try
            {
                var res = await Task.Run(() => _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(userName)));
                await _unitOfWork.UserManager.SetLockoutEndDateAsync(res.Id, DateTimeOffset.MinValue);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<OperationDetails> CreateAsync(ApplicationUserDTO userDto)
        {
            try
            {
                ApplicationUser user = await _unitOfWork.UserManager.FindByNameAsync(userDto.UserName);
                if (user == null)
                {
                    user = _mapper.Map<ApplicationUser>(userDto);
                    user.LockoutEnabled = true;
                    await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);
                    await _unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                    await _unitOfWork.SaveAsync();
                    return new OperationDetails(true, "Регистрация успешно пройдена", "");
                }

                return new OperationDetails(false, "Пользователь с таким логином уже существует", "UserName");
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(ApplicationUserDTO userDto)
        {
            try
            {
                ClaimsIdentity claim = null;
                ApplicationUser user = await _unitOfWork.UserManager.FindAsync(userDto.UserName, userDto.Password);
                if (user != null)
                    claim = await user.GenerateUserIdentityAsync(_unitOfWork.UserManager);
                return claim;
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }
    }
}

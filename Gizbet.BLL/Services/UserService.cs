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
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = GetMapper();
        }

        public async Task<ApplicationUserDTO> GetUserByUserNameAsync(string userName)
        {
            var res = await Task.Run(() => _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName.Equals(userName)));
            return _mapper.Map<ApplicationUserDTO>(res);
        }

        public async Task<OperationDetails> CreateAsync(ApplicationUserDTO userDto)
        {
            ApplicationUser user = await _unitOfWork.UserManager.FindByNameAsync(userDto.UserName);
            if (user == null)
            {
                user = _mapper.Map<ApplicationUser>(userDto);
                await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);
                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                await _unitOfWork.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }

            return new OperationDetails(false, "Пользователь с таким логином уже существует", "UserName");
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(ApplicationUserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _unitOfWork.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user != null)
                claim = await user.GenerateUserIdentityAsync(_unitOfWork.UserManager);
            return claim;
        }
    }
}

using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.WEB.Models;

namespace Gizbet.WEB.Configuration
{
    public static class AutoMapperConfigurationWEB
    {
        public static IMapper Mapper;

        static AutoMapperConfigurationWEB()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUserLoginModel, ApplicationUserDTO>();
                cfg.CreateMap<ApplicationUserRegisterModel , ApplicationUserDTO>();
                cfg.CreateMap<ApplicationUserDTO, ApplicationUserPublicModel>().MaxDepth(3);

                cfg.CreateMap<CategoryDTO, CategoryModel>().MaxDepth(3);
                cfg.CreateMap<CategoryModel, CategoryDTO>()
                    .ForMember(x => x.Lots, opt => opt.Ignore());

                cfg.CreateMap<BidDTO, BidModel>().MaxDepth(3);

                cfg.CreateMap<LotDTO, LotPublicModel>().MaxDepth(3);
                cfg.CreateMap<LotAddModel, LotDTO>();

            }).CreateMapper();
        }
    }
}

using System;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.WEB.Models;

namespace Gizbet.WEB.Configuration
{
    public static class AutoMapperConfigurationWEB
    {
        private static MapperConfiguration _config;

        static AutoMapperConfigurationWEB()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUserLoginModel, ApplicationUserDTO>();
                cfg.CreateMap<ApplicationUserRegisterModel, ApplicationUserDTO>();
                cfg.CreateMap<ApplicationUserDTO, ApplicationUserPublicModel>()
                    .ForMember(x => x.IsBanned, opt => opt.ResolveUsing(x => x.LockoutEnabled && x.LockoutEndDateUtc >= DateTime.Now))
                    .MaxDepth(3);

                cfg.CreateMap<CategoryDTO, CategoryModel>().MaxDepth(3);
                cfg.CreateMap<CategoryModel, CategoryDTO>()
                    .ForMember(x => x.Lots, opt => opt.Ignore());

                cfg.CreateMap<BidDTO, BidModel>()
                    .ForMember(x => x.IsTop, opt => opt.ResolveUsing(x => x.Lot.TopBid?.Id == x.Id))
                    .ForMember(x => x.IsWin, opt => opt.ResolveUsing(x => x.Lot.TopBid?.Id == x.Id && x.Lot.IsSold))
                    .MaxDepth(3);

                cfg.CreateMap<LotDTO, LotPublicModel>().MaxDepth(3);
                cfg.CreateMap<LotDTO, LotAddModel>().MaxDepth(3);
                cfg.CreateMap<LotAddModel, LotDTO>();

            });
        }

        public static Mapper GetMapper()
        {
            return new Mapper(_config);
        }
    }
}

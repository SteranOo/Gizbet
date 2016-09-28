using System;
using System.Linq;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Entities.Identity;

namespace Gizbet.BLL.Configuration
{
    public static class AutoMapperConfigurationBLL
    {
        private static MapperConfiguration _config;

        static AutoMapperConfigurationBLL()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bid, BidDTO>().MaxDepth(3);
                cfg.CreateMap<BidDTO, Bid>()
                    .ForMember(x => x.ApplicationUser, opt => opt.Ignore())
                    .ForMember(x => x.Lot, opt => opt.Ignore());

                cfg.CreateMap<Category, CategoryDTO>().MaxDepth(3);
                cfg.CreateMap<CategoryDTO, Category>()
                    .ForMember(x => x.Lots, opt => opt.Ignore());

                cfg.CreateMap<Lot, LotDTO>()
                    .ForMember(x=>x.TopBid, opt=>opt.ResolveUsing(x=>x.Bids?.OrderByDescending(b=>b.Amount).FirstOrDefault()))    
                    .MaxDepth(3);

                cfg.CreateMap<LotDTO, Lot>()
                    .ForMember(x => x.Bids, opt => opt.Ignore())
                    .ForMember(x => x.Category, opt => opt.Ignore())
                    .ForMember(x => x.Owner, opt => opt.Ignore());

                cfg.CreateMap<Response, ResponseDTO>().MaxDepth(3);
                cfg.CreateMap<ResponseDTO, Response>()
                    .ForMember(x => x.Author, opt => opt.Ignore())
                    .ForMember(x => x.Recipient, opt => opt.Ignore());

                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>().MaxDepth(3);
                cfg.CreateMap<ApplicationUserDTO, ApplicationUser>()
                    .ForMember(x => x.ReceivedResponses, opt => opt.Ignore())
                    .ForMember(x => x.SentResponses, opt => opt.Ignore())
                    .ForMember(x => x.Bids, opt => opt.Ignore())
                    .ForMember(x => x.Lots, opt => opt.Ignore());
            });
        }

        public static Mapper GetMapper()
        {
            return new Mapper(_config);
        }
    }
}

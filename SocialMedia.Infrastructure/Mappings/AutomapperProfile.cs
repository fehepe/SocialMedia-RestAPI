using AutoMapper;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Source --> Destination

            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Security, SecurityDto>().ReverseMap();

        }
    }
}

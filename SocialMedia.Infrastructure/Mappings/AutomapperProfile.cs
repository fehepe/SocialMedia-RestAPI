using AutoMapper;
using SocialMedia.Core.Data;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Source --> Destination

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

        }
    }
}



namespace SocialMedia.Infrastructure.Mappings
{
    using AutoMapper;
    using Core.DTOs;
    using Core.Entities;
    public class AutomapperProfile : Profile
    {
        // create mapping here it is the convertion
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}

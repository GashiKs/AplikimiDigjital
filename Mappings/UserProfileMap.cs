using AutoMapper;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;

namespace AplikimiDigjital.Mappings
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Aplikimi, AplikimiEntity>().ReverseMap();
            CreateMap<Comment, CommentEntity>().ReverseMap();
        }
    }
}

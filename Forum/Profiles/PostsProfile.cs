using AutoMapper;
using CrimerForum.Data.Models;
using CrimerForum.VM.Post;

namespace CrimerForum.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<Post, PostVM>();
        }
    }
}
using AutoMapper;
using CrimerForum.Data.Models;
using CrimerForum.VM.Reply;

namespace CrimerForum.Profiles
{
    public class RepliesProfile : Profile
    {
        public RepliesProfile()
        {
            CreateMap<PostReply, PostReplyVM>();
        }
    }
}
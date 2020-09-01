using System;
using System.Collections.Generic;
using CrimerForum.VM.Post;
using Microsoft.AspNetCore.Http;

namespace CrimerForum.VM.ApplicationUser
{
    public class ProfileVM
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserRating { get; set; }
        public string UserImage { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime MemberSince { get; set; }
        public IFormFile Image { get; set; }
        public IEnumerable<PostVM> UserPosts { get; set; }
    }
}
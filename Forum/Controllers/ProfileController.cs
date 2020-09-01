using System.Collections.Generic;
using System.Linq;
using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.ApplicationUser;
using CrimerForum.VM.Post;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrimerForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        private readonly IPost _postService;
        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService,
            IPost postService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
            _postService = postService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllUsers()
        {
            return View();
        }
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRole = _userManager.GetRolesAsync(user).Result;
            var userPosts = _postService.GetPostsByUser(user.Id);
            var model = new ProfileVM()
            {
                UserId = user.Id,
                Email = user.Email,
                IsAdmin = userRole.Contains("Admin"),
                MemberSince = user.MemberSince,
                UserImage = user.ProfileImage,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                UserPosts = BuildPosts(userPosts)
            };
            return View(model);
        }

        private IEnumerable<PostVM> BuildPosts(IEnumerable<Post> userPosts)
        {
            return userPosts.Select(p => new PostVM()
            {
                Id = p.Id,
                Content = p.Content,
                Title = p.Title,
                AuthorId = p.Author.Id,
                AuthorName = p.Author.UserName,
                AuthorRating = p.Author.Rating,
                CreatedAt = p.CreatedAt,
                RepliesCount = p.Replies.Count(),
            });

        }

        // PUT
        // [HttpPost]
        // public IActionResult Edit(ProfileVM profileVM)
        // {
        //     
        // }
    }
}
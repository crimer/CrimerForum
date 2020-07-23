using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.Forum;
using CrimerForum.VM.Home;
using CrimerForum.VM.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrimerForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;
        public HomeController(ILogger<HomeController> logger, IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexVM();
            return View(model);
        }

        private HomeIndexVM BuildHomeIndexVM()
        {
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(p => new PostVM
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                AuthorName = p.Author.UserName,
                AuthorId = p.Author.Id,
                AuthorRating = p.Author.Rating,
                CreatedAt = p.CreatedAt,
                Forum = GetForumForPosts(p),
                RepliesCount = p.Replies.Count()
            });
            return new HomeIndexVM { LatestPosts = posts, SearchQuery = "" };
        }

        private ForumVM GetForumForPosts(Post post)
        {
            var forum = post.Forum;
            return new ForumVM
            {
                Id = forum.Id,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl,
                Title = forum.Title
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}

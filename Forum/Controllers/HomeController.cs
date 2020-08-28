using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.Forum;
using CrimerForum.VM.Home;
using CrimerForum.VM.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public IActionResult Index(string? searchQuery)
        {
            HomeIndexVM model = null;
            if (string.IsNullOrEmpty(searchQuery))
            {
                model = BuildHomeIndexVM();
            }
            else
            {
                var posts = _postService.GetFilteredPosts(searchQuery);
                bool isNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());
                var postsVM = posts.Select(post => new PostVM()
                {
                    Id = post.Id,
                    Content = post.Content,
                    AuthorId = post.Author.Id,
                    AuthorName = post.Author.UserName,
                    Title = post.Title,
                    CreatedAt = post.CreatedAt,
                    RepliesCount = post.Replies.Count(),
                    Forum = GetForumForPosts(post)
                }); 
                model = new HomeIndexVM()
                    {Posts = postsVM, SearchQuery = searchQuery, IsEmptySearchResult = isNoResults};
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Index", new {searchQuery});
        }
        private HomeIndexVM BuildHomeIndexVM()
        {
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(p => new PostVM
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                //AuthorName = p.Author.UserName,
                //AuthorId = p.Author.Id,
                //AuthorRating = p.Author.Rating,
                CreatedAt = p.CreatedAt,
                Forum = GetForumForPosts(p),
                RepliesCount = p.Replies.Count()
            });
            bool emptyResults = (!latestPosts.Any());
            return new HomeIndexVM {Posts = posts, SearchQuery = "", IsEmptySearchResult = emptyResults};
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


    }
}

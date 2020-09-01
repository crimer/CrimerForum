using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.Forum;
using CrimerForum.VM.Post;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrimerForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            IEnumerable<ForumVM> forums = _forumService.GetAll()
                .Select(forum => new ForumVM
                {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description,
                    PostsCount = forum.Posts.Count()
                });
            var vm = new ForumIndexVM() { ForumList = forums };
            return View(vm);
        }
        public IActionResult Topic(int id, string searchQuery)
        {
            var forum = _forumService.GetById(id);

            ForumVM forumVM = BuildForumModel(forum);
            
            var posts = new List<Post>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                posts = _postService.GetFilteredPosts(forum, searchQuery).ToList();

            }
            else
            {
                posts = forum.Posts.ToList();

            }
            var postsTopicVM = posts.Select(p => new PostVM()
            {
                Id = p.Id,
                Title = p.Title,
                //AuthorId = p.Author.Id,
                //AuthorName = p.Author.UserName,
                //AuthorRating = p.Author.Rating,
                CreatedAt = p.CreatedAt,
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumModel(p)
            });

            ForumTopicVM topicVM = new ForumTopicVM() { Forum = forumVM, Posts = postsTopicVM };

            return View(topicVM);
        }
        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }
        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST
        // [HttpPost]
        // public IActionResult Create(CreateForumVM createForumVm)
        // {
        //     
        // }
        private ForumVM BuildForumModel(Post post)
        {
            var forum = post.Forum;
            return BuildForumModel(forum);
        }
        private ForumVM BuildForumModel(Forum forum)
        {
            return new ForumVM()
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}

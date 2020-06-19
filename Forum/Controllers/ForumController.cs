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
                    Name = forum.Title,
                    Description = forum.Description
                });
            var vm = new ForumIndexVM() { ForumList = forums };
            return View(vm);
        }
        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);

            ForumVM forumVM = BuildForumModel(forum);

            var posts = _postService.GetPostsByForum(id);
            var postsTopicVM = posts.Select(p => new PostVM()
            {
                Id = p.Id,
                Title = p.Title,
                AuthorId = p.Author.Id,
                AuthorRating = p.Author.Rating,
                DatePosted = p.CreatedAt,
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumModel(p)
            });

            ForumTopicVM topicVM = new ForumTopicVM() { Forum = forumVM, Posts = postsTopicVM };

            return View(topicVM);
        }
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
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}

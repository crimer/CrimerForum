
using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.Post;
using CrimerForum.VM.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CrimerForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            Post post = _postService.GetById(id);
            var replies = _mapper.Map<IEnumerable<PostReplyVM>>(post.Replies);
            var vm = new PostIndexVM()
            {
                Id = post.Id,
                DatePosted = post.CreatedAt,
                Title = post.Title,
                AuthorId = post.Author.Id,
                AuthorImageUrl = post.Author.ProfileImage,
                AuthorName = post.Author.UserName,
                AuthorRating = post.Author.Rating,
                Content = post.Content,
                Replies = replies
            };
            return View(vm);
        }
        
        [HttpGet]
        public IActionResult Create(int id)
        {
            var forum = _forumService.GetById(id);
            var model = new CreatePostVM()
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostVM createPostVM)
        {
            string userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var post = BuildPost(createPostVM, user);
            await _postService.AddPost(post);
            return RedirectToAction("Index","Post", new { id = post.Id });
        }

        private Post BuildPost(CreatePostVM createPostVM, ApplicationUser user)
        {
            var forum = _forumService.GetById(createPostVM.ForumId);
            return new Post
            {
                Title = createPostVM.Title,
                Content = createPostVM.Content,
                CreatedAt = DateTime.Now,
                Author = user,
                Forum = forum
            };
        }
    }
}
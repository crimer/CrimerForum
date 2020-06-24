
using CrimerForum.Data;
using CrimerForum.Data.Models;
using CrimerForum.VM.Post;
using CrimerForum.VM.Reply;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrimerForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);
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

        private IEnumerable<PostReplyVM> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(r => new PostReplyVM()
            {
                Id = r.Id,
                AuthorId = r.Author.Id,
                AuthorName = r.Author.UserName,
                AuthorImageUrl = r.Author.ProfileImage,
                AuthorRating = r.Author.Rating,
                Created = r.CreatedAt,
                RepliesContent = r.Content
            });
        }
        public IActionResult Create(PostVM postVM)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PostVM postVM)
        {
            return View();
        }
    }
}
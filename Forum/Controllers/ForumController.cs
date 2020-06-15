using CrimerForum.Data;
using CrimerForum.VM.Forum;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrimerForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
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
            ForumVM vm = new ForumVM() { Id = forum.Id, Description = forum.Description, Name = forum.Title };
            return View(vm);
        }
    }
}

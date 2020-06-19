using CrimerForum.Data;
using CrimerForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimerForum.Services
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(f => f.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(forum => forum.Id == id)
                .Include(forum => forum.Posts).ThenInclude(post => post.Author)
                .Include(forum => forum.Posts).ThenInclude(post => post.Replies).ThenInclude(reply => reply.Author)
                .FirstOrDefault();
            return forum;
        }

        public Task UpdateDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateImage(int forumId, string newUrlImage)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}

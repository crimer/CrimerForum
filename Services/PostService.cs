using CrimerForum.Data;
using CrimerForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimerForum.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int postId, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.Include(p => p.Author)
                .Include(p => p.Replies).ThenInclude(r => r.Author)
                .Include(p => p.Forum);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(p => p.Id == id)
                .Include(p => p.Author)
                .Include(p => p.Replies).ThenInclude(r => r.Author)
                .Include(p => p.Forum)
                .FirstOrDefault();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int forumId)
        {
            return _context.Forums.Where(f => f.Id == forumId).FirstOrDefault().Posts;
                
        }

        public IEnumerable<Post> GetLatestPosts(int count)
        {
            return GetAllPosts().OrderByDescending(p => p.CreatedAt).Take(count);
        }
    }
}

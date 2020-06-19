using CrimerForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimerForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetPostsByForum(int forumId);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        Task AddPost(Post post, int forumId);
        Task AddPost(Post post, int forumId);
    }
}

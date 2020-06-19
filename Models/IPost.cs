using CrimerForum.Data.Models;
using System.Collections.Generic;
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
        Task DeletePost(int postId);
        Task EditPostContent(int postId, string newContent);
        Task AddReply(PostReply reply);
    }
}

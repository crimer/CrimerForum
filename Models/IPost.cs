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
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetLatestPosts(int count);
        Task AddPost(Post post);
        Task DeletePost(int postId);
        Task EditPostContent(int postId, string newContent);
        Task AddReply(PostReply reply);
    }
}

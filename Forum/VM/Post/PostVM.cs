using CrimerForum.VM.Forum;
using System;

namespace CrimerForum.VM.Post
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorRating { get; set; }
        public int AuthorId { get; set; }
        public DateTime DatePosted { get; set; }
        public int RepliesCount { get; set; }
        public ForumVM Forum { get; set; }
    }
}

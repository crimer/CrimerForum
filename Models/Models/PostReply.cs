using System;

namespace CrimerForum.Data.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Post Post { get; set; }

    }
}

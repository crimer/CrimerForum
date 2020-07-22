using System;
using System.Collections.Generic;

namespace CrimerForum.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
    }
}

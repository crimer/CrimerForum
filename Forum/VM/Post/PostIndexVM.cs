using CrimerForum.VM.Reply;
using System;
using System.Collections.Generic;

namespace CrimerForum.VM.Post
{
    public class PostIndexVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }

        public IEnumerable<PostReplyVM> Replies { get; set; }
    }
}

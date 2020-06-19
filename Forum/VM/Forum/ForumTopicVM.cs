using CrimerForum.VM.Post;
using System.Collections.Generic;

namespace CrimerForum.VM.Forum
{
    public class ForumTopicVM
    {
        public ForumVM Forum { get; set; }
        public IEnumerable<PostVM> Posts { get; set; }
    }
}

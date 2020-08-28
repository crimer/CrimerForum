using System.Collections.Generic;
using CrimerForum.VM.Post;

namespace CrimerForum.VM.Search
{
    public class SearchResultVM
    {
        public IEnumerable<PostVM> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResult { get; set; }
    }
}
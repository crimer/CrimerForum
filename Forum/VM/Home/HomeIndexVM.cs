﻿using CrimerForum.VM.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimerForum.VM.Home
{
    public class HomeIndexVM
    {
        public string SearchQuery { get; set; }
        public bool IsEmptySearchResult { get; set; }
        public IEnumerable<PostVM> Posts { get; set; }
    }
}

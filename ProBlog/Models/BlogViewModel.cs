﻿using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProBlog.Models
{
    public class BlogViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Pagination PageInfo { get; set; }
    }
}
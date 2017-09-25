using ProBlog.Business;
using ProBlog.Core;
using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProBlog.Models
{
    public class PostsListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        //public string CategoryName { get; set; }
    }
}
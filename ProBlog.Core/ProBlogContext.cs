using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Core
{
    public class ProBlogContext : DbContext
    {
        public ProBlogContext()
            : base("ProBlogDbConnection")
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

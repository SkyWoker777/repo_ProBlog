using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Core
{
    public class Repository : IRepository
    {
        private ProBlogContext context;
        public Repository()
        {
            context = new ProBlogContext();
        }
        public IEnumerable<Post> Posts => context.Posts.Include("Category").ToList();
        public IEnumerable<Category> Categories => context.Categories.ToList();
        public IEnumerable<Tag> Tags => context.Tags.ToList();

        public void Add<T>(T entity) where T : ProBlog.Core.Etities.Entity
        {
            context.Set<T>().Add(entity);
        }
        public void Delete<T>(T entity) where T : ProBlog.Core.Etities.Entity
        {
            context.Set<T>().Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

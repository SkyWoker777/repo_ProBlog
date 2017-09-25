using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Core
{
    public interface IRepository
    {
        IEnumerable<Post> Posts { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<Tag> Tags { get; }

        void Add<T>(T entity) where T : ProBlog.Core.Etities.Entity;
        void Delete<T>(T entity) where T : ProBlog.Core.Etities.Entity;
        void SaveChanges();
    }
}

using ProBlog.Core;
using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Business
{
    public class PostHelper
    {
        private readonly IRepository _context;
        private CategoryHelper _categories;

        public PostHelper(IRepository repository)
        {
            _context = repository;
            _categories = new CategoryHelper(this._context);
        }

        public void AddPost(string title, string content, int categoryId)
        {
            var post = new Post();
            post.Title = title;
            post.Content = content;
            post.Category = _categories.GetCategory(categoryId);
            post.Preview = content.Substring(0, content.Length / 2);
            post.PostedOn = DateTime.Now;
            _context.Add(post);
            _context.SaveChanges();
        }
        public void DeletePost(int id)
        {
            var post = GetPost(id);
            _context.Delete(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts;
        }

        public IEnumerable<Post> GetPosts(int categoryId)
        {
            return _context.Posts.Where(x => x.Category != null && x.Category.Id == categoryId).ToList();
        }

        public Post GetPost(int id)
        {
            return _context.Posts.First(x => x.Id == id);
        }
    }
}

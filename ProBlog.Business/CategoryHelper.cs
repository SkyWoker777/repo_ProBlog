using ProBlog.Core;
using ProBlog.Core.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Business
{
    public class CategoryHelper
    {
        private readonly IRepository _context;

        public CategoryHelper(IRepository repository)
        {
            _context = repository;
        }

        public void AddCategory(string name)
        {
            var category = new Category();
            category.Name = name;
            _context.Add(category);
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = GetCategory(id);
            _context.Delete(category);
            _context.SaveChanges();
        }
        public Category EditCategory(int id, string name)
        {
            var category = GetCategory(id);
            category.Name = name;
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.Select(x => { x.PostsCount = _context.Posts.Count(a => a.Category.Id == a.Id); return x; });
        }
        public Category GetCategory(int id)
        {
           return _context.Categories.First(c => c.Id == id);
        } 
    }
}

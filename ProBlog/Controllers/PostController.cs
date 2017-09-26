using ProBlog.Business;
using ProBlog.Core;
using ProBlog.Core.Etities;
using ProBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProBlog.Controllers
{
    public class PostController : Controller
    {
        private PostHelper _helper = new PostHelper(new Repository());
        private CategoryHelper _categoryHelper = new CategoryHelper(new Repository());

        // GET: /Post/List?page=1
        public ActionResult List(int page = 1)
        {
            int pageSize = 3;
            List<Post> posts = new List<Post>(_helper.GetPosts()
                .OrderByDescending(x => x.PostedOn)
                .ToList()
                ); 
            IEnumerable<Post> postsOnPages = posts.Skip((page - 1) * pageSize).Take(pageSize);
            Pagination pageInfo = new Pagination() { PageNumber = page, PageSize = pageSize, TotalItems = posts.Count };

            BlogViewModel viewModel = new BlogViewModel()
            {
                Posts = postsOnPages,
                Categories = _categoryHelper.GetCategories(),
                PageInfo = pageInfo
            };
            if (viewModel.Posts == null)
                throw new HttpException(404, "Posts not found!");

            return View(viewModel);
        }

        //GET: /Post/ListByCategory/3/page1
        public ActionResult ListByCategory(int categoryId, string categoryName, int page)
        {
            int pageSize = 3;
            List<Post> posts = new List<Post>(_helper.GetPosts(categoryId)
                .OrderByDescending(x => x.PostedOn)
                .ToList()
                );
            IEnumerable<Post> postsOnPages = posts.Skip((page - 1) * pageSize).Take(pageSize);
            Pagination pageInfo = new Pagination() { PageNumber = page, PageSize = pageSize, TotalItems = posts.Count };

            ViewBag.CategoryName = categoryName;

            BlogViewModel viewModel = new BlogViewModel()
            {
                Posts = postsOnPages,
                Categories = _categoryHelper.GetCategories(),
                PageInfo = pageInfo
            };
            if (viewModel.Posts == null)
                throw new HttpException(404, "Posts not found!");

            return View("PostsForCategory", viewModel);
        }

        // GET: /Post/ReadMore/1
        public ViewResult ReadMore(int id)
        {
            var post = _helper.GetPost(id);
            if (post == null)
            {
                throw new HttpException(404, "post not found!");
            }

            return View(post);
        }

        public FileContentResult GetImage(int postId)
        {
            var post = _helper.GetPost(postId);
            if (post != null)
            {
                return File(post.ImageData, post.ImageMimeType);
            }
            else { return null; }
        }
    }
}
using ProBlog.Business;
using ProBlog.Core;
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

        // GET: /Post/List
        public ActionResult List()
        {
            PostsListViewModel viewModel = new PostsListViewModel()
            {
                Posts = _helper.GetPosts(),
                Categories = _categoryHelper.GetCategories()
            };
            return View(viewModel);
        }

        //GET: /Post/PostsForCategory/3
        public ActionResult PostsForCategory(int categoryId)
        {
            PostsListViewModel viewModel = new PostsListViewModel()
            {
                Posts = _helper.GetPosts(categoryId),
                Categories = _categoryHelper.GetCategories()
            };
            return View(viewModel);
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
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    public class MyBlogsController : Controller
    {
        public List<Blog> Blogs { get; set; }
        public MyBlogsController()
        {
            var myBlog1 = new Blog();
            myBlog1.Id = 1;
            myBlog1.Title = "Hello from me";
            myBlog1.Description = "This is some description";
            myBlog1.DateCreated = DateTime.Now;

            var myBlog2 = new Blog();
            myBlog2.Id = 2;
            myBlog2.Title = "Hello from the other side";
            myBlog2.Description = "This is some description number 2.";
            myBlog2.DateCreated = DateTime.Now;

            Blogs = new List<Blog> { myBlog1, myBlog2 };
        }
        public IActionResult Overview()
        {
          
            return View(Blogs);
        }
        public IActionResult Details(int id)
        {
            var blogs = Blogs.FirstOrDefault(x => x.Id == id);
            if (blogs == null)
            {
               return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(blogs);
        }
    }
}

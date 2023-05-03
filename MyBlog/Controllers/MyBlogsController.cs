using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class MyBlogsController : Controller
    {
        public IActionResult Overview()
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

            var myBlogs = new List<Blog> { myBlog1, myBlog2 };



            return View(myBlogs);
        }
    }
}

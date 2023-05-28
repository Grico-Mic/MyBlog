using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Servises;
using MyBlog.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    public class MyBlogsController : Controller
    {
        public IMyBlogsServise _servise { get; set; }
        public MyBlogsController(IMyBlogsServise blogsServise)
        {
            _servise = blogsServise;
        }
        public IActionResult Overview(string title)
        {
            var blogs = _servise.GetBlogByTitle(title);
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            var blogs = _servise.GetById(id);
            if (blogs == null)
            {
               return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(blogs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _servise.Create(blog);
               return RedirectToAction("Overview");
            }

            return View(blog);
        }
    }
}

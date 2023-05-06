using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Servises;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    public class MyBlogsController : Controller
    {
        public MyBlogsServise _servise { get; set; }
        public MyBlogsController()
        {
            _servise = new MyBlogsServise();
        }
        public IActionResult Overview()
        {
            var blogs = _servise.GetAll();
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
    }
}

using Microsoft.AspNetCore.Mvc;
using MyBlog.Common;
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
        public IActionResult ManageBlogs(string errorMessage , string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var blogs = _servise.GetAll();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            try
            {
                var blogs = _servise.GetById(id);
                if (blogs == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(blogs);
            }
            catch (Exception)
            {

                return RedirectToAction("InternalError", "Info"); ;
            }
           
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
               return RedirectToAction("ManageBlogs", new { SuccessMessage = "The blog was created successfully." });
            }

            return View(blog);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _servise.Delete(id);
                return RedirectToAction("ManageBlogs", new { SuccessMessage = "The movie was deleted successfully." });
            }
            catch (NotFoundException ex)
            {

                return RedirectToAction("ManageBlogs", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
            [HttpGet]
            public IActionResult Update(int id)
            {
                var blog = _servise.GetById(id);
                return View(blog);
            }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _servise.Update(blog);
                    return RedirectToAction("ManageBlogs", new { SuccessMessage = "The movie was updated successfully." });
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("ManageBlogs", new { ErrorMessage = ex.Message });
                    
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError","Info");
                }   
               
            }
            return View(blog);
        }


    }
}

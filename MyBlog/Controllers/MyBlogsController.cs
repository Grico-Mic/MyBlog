﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Servises.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MyBlogsController : Controller
    {
       
        public IMyBlogsServise _servise { get; set; }
        public MyBlogsController(IMyBlogsServise blogsServise)
        {
            _servise = blogsServise;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {

            var blogs = _servise.GetBlogByTitle(title);
            var listOverviewModel = new List<BlogOverviewModel>();

            var blogOverviewModel = blogs.Select(x => x.ToOverviewModel()).ToList();
            return View(blogOverviewModel);
        }
        public IActionResult ManageBlogs(string errorMessage , string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
           var blogs = _servise.GetAll();
            var manageBlogsModel = blogs.Select(x => x.ToManageBlogsModel()).ToList();
            return View(manageBlogsModel);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var blogs = _servise.GetById(id);
                if (blogs == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(blogs.ToDetailsModel());
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
        public IActionResult Create(BlogCreateModel blog)
        {
            if (ModelState.IsValid)
            {
                var domainModel = blog.ToModel();
                _servise.Create(domainModel);
               return RedirectToAction("ManageBlogs", new { SuccessMessage = "The blog was created successfully." });
            }

            return View(blog);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = _servise.Delete(id);
                if (response.IsSuccessful)
                {
                return RedirectToAction("ManageBlogs", new { SuccessMessage = "The movie was deleted successfully." });
                }
                else
                {
                    return RedirectToAction("ManageBlogs", new { ErrorMessage = response.Message });
                }
            }
          
            catch (Exception )
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
            [HttpGet]
            public IActionResult Update(int id)
            {
                var blog = _servise.GetById(id);
                return View(blog.ToUpdateModel());
            }
        [HttpPost]
        public IActionResult Update(BlogUpdateModel blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _servise.Update(blog.ToModel());
                    if (response.IsSuccessful)
                    {
                    return RedirectToAction("ManageBlogs", new { SuccessMessage = "The movie was updated successfully." });
                    }
                    else
                    {
                    return RedirectToAction("ManageBlogs", new { ErrorMessage = response.Message });
                    }
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

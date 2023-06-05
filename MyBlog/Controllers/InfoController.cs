using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ErrorNotFound()

        {
            return View();
        }
        public IActionResult ActionNotSuccessfull(string message)

        {
            ViewBag.Message = message;
            return View();
        }
        public IActionResult InternalError(string message)

        {
            ViewBag.Message = message;
            return View();
        }
    }
}


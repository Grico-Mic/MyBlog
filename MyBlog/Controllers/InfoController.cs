using Microsoft.AspNetCore.Mvc;

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


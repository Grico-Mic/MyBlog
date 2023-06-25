using Microsoft.AspNetCore.Mvc;
using MyBlog.Servises.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(AuthSignInModel authSignInModel)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(authSignInModel.Username, authSignInModel.Password, HttpContext);
                if (response.IsSuccessful == true)
                {
                    return RedirectToAction("Overview", "MyBlogs");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(authSignInModel);
                }
            }
            return View(authSignInModel);
        }
    }
}

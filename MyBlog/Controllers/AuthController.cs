using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Servises.Interfaces;
using MyBlog.ViewModels;

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
        public IActionResult SignIn(AuthSignInModel authSignInModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(authSignInModel.Username, authSignInModel.Password,authSignInModel.IsPersistent, HttpContext);
                if (response.IsSuccessful == true)
                {
                    if (returnUrl == null)
                    {
                    return RedirectToAction("Overview", "MyBlogs");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(authSignInModel);
                }
            }
            return View(authSignInModel);
        }

        public IActionResult SignOut()
        {
            _authService.SignOut(HttpContext);
            return  RedirectToAction("Overview", "MyBlogs");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(AuthSignUpModel authSignUpModel)
        {
            if (ModelState.IsValid)
            {
                var response = _authService.SignUp(authSignUpModel.ToSignUpModel());
                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(authSignUpModel);
                }

            }
            else
            {
                return View(authSignUpModel);
            }

        }
    }
}
 
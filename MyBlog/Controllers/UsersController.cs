using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Servises.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Linq;

namespace MyBlog.Controllers
{
   
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [Authorize]
        public IActionResult Details(string SuccessMessage,string ErrorMessage)
        {
            try
            {
                ViewBag.ErrorMessage = ErrorMessage;
                ViewBag.SuccessMessage = SuccessMessage;
                var userId = User.FindFirst("Id").Value;
                var user = _usersService.GetDetails(userId);
                if (user == null)
                {
                    RedirectToAction("ErrorNotFound", "Info");
                }
                return View(user.ToUsersDetailsModel());
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");

            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult UpdateUser()
        {
            try
            {
                var userId = User.FindFirst("Id").Value;
                var user = _usersService.GetDetails(userId);

                if (user == null)
                {
                    RedirectToAction("ErrorNotFound", "Info");
                }
                return View(user.ToUpdateModel());
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
           
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateUser(UsersUpdateModel usersUpdateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = usersUpdateModel.ToUpdateModel();
                    user.Id = int.Parse(User.FindFirst("Id").Value);
                    var response = _usersService.UpdateUser(user);
                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("Details",  new { SuccessMessage = "User was updated successfully."  });
                    }
                    else
                    {
                        return RedirectToAction("Details", new { ErrorMessage = $"The User with id {user.Id} was not found" });
                    }
                }
                catch (Exception)
                {
                   return RedirectToAction("InternalError", "Info");
                }
            }
            return View(usersUpdateModel);
        }
        [Authorize (Policy = "IsAdmin") ]
        public IActionResult ManageUsers(string SuccessMessage, string ErrorMessage)
        {
            ViewBag.ErrorMessage = ErrorMessage;
            ViewBag.SuccessMessage = SuccessMessage;
            var id = int.Parse(User.FindFirst("Id").Value);
            var users = _usersService.GetAll();
            var viewModel = users.Where(x => x.Id != id).Select(x => x.ToManageUsersModel()).ToList();
            return View(viewModel);
        }
        [Authorize (Policy = "IsAdmin") ]
        public IActionResult ToggleAdminRole(int id)
        { 
                var response = _usersService.ToggleAdminRole(id);
            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageUsers", new {SuccessMessage = "User role updated successfuly" });
            }
            else
            {
                return RedirectToAction("ManageUsers", new { response.Message });
            }  
        }

        public IActionResult Delete(int id)
        {
            var response = _usersService.Delete(id);
            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageUsers", new { SuccessMessage = "User was deleted successfuly" });
            }
            else
            {
                return RedirectToAction("ManageUsers", new { response.Message });
            }
        }
    }
}

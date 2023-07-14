﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Servises.Interfaces;
using MyBlog.ViewModels;
using System;

namespace MyBlog.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

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
                        return RedirectToAction("Details",  new { SuccessMessage = "The blog was updated successfully."  });
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
    }
}

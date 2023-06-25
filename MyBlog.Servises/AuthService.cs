﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.DtoModels;
using MyBlog.Servises.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Servises
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public StatusModel SignIn(string username, string password, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetByUsername(username);
            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim("Username",user.Username),
                    new Claim("Email",user.Email),
                    new Claim("Address",user.Address)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                Task.Run(() => httpContext.SignInAsync(principal)).GetAwaiter().GetResult();

                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Invalid username or password.";
            }
            return response;
        }
    }
}
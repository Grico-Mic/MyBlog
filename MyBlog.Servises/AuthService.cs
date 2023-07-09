using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Models;
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
        public StatusModel SignIn(string username, string password,bool IsPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password,user.Password))
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

                var authProps = new AuthenticationProperties() { IsPersistent = IsPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();

                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Invalid username or password.";
            }
            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SignUp(User signUpUser)
        {
            var response = new StatusModel();
            var user = _usersRepository.CheckIfExist(signUpUser.Username,signUpUser.Email);
            if (user)
            {
                response.IsSuccessful = false;
                response.Message = "User with username or email already exist";
                return response;
            }

            var newUser = new User()
            {
                Username = signUpUser.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(signUpUser.Password),
                Address = signUpUser.Address,
                Email = signUpUser.Email

            };
            _usersRepository.Add(newUser);
            return response;
        }
    }
}

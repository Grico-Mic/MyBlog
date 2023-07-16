using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.DtoModels;
using MyBlog.Servises.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Servises
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetById(id);
            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User does not exist";  
            }
            else
            {
                _usersRepository.Delete(user);
            }
            return response;
           
        }

        public List<User> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetById(id);
            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User was not exist";
            }
            else
            {
                user.IsAdmin = !user.IsAdmin;
                _usersRepository.Update(user);
            }
            return response;
        }

        public StatusModel UpdateUser(User user)
        {
            var response = new StatusModel();
            var UpdatedUser = _usersRepository.GetById(user.Id);
            if (response != null)
            {
                UpdatedUser.Username = user.Username;
                UpdatedUser.Address = user.Address;
                UpdatedUser.Email = user.Email;

                _usersRepository.Update(UpdatedUser);
                response.IsSuccessful = true;
               
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The User with id {user.Id} was not found";
            }

            return response;
        }
    }
}
        
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.DtoModels;
using MyBlog.Servises.Interfaces;

namespace MyBlog.Servises
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
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
                response.Message = "User was updated successfully.";
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
        
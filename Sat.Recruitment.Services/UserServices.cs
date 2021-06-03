using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.DTO;
using Sat.Recruitment.Services.Repository;

namespace Sat.Recruitment.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserFactory _userfactory;
        private readonly IUserRepository _userRepository;

        public UserServices(IUserFactory factory, IUserRepository repository) {
            _userfactory = factory ?? throw new ArgumentNullException(nameof(factory));
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        public User CreateUser(UserDTO user)
        {
            User newUser = _userfactory.createUser(user);
            _userRepository.insertUser(newUser);
            return newUser;
        }
        public User getUser(String email)
        {
            return _userRepository.getUser(email);
        }

        public List<User> getUsers(String email)
        {
            return _userRepository.getUsers();
        }
    }
}

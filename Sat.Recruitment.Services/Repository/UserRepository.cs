using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.Util;
using Sat.Recruitment.Model.DTO;

using Sat.Recruitment.Services.Helpers;

namespace Sat.Recruitment.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly IUserFactory _factory;
       public UserRepository(IUserFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public User insertUser(User user) {
            if (_users.Exists(u =>(( String.Equals(u.Email, user.Email) || String.Equals(u.Phone,user.Phone)) || (String.Equals(u.Name,user.Name) && String.Equals(u.Address , user.Address)))))
            {
                throw new DuplicatedUserException();
            }
            else {
                _users.Add(user);
            }
            return user;
        }

        public User getUser(String email) {
            return _users.Find(c => String.Equals(c.Email, email)); 
        }

        public List<User> getUsers() {

            return _users;
        }

        public void Initialize() {
            var reader = FileHelper.ReadUsersFromFile();
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var userSplit = line.Split(',');
                var userDTO = new UserDTO()
                {
                    Name = userSplit[0].ToString(),
                    Email = userSplit[1].ToString(),
                    Phone = userSplit[2].ToString(),
                    Address = userSplit[3].ToString(),
                    UserType = userSplit[4].ToString(),
                    Money = decimal.Parse(userSplit[5].ToString()),
                };
                var user = _factory.createUser(userDTO);
                _users.Add(user);
            }
            reader.Close();
        }
    }
}

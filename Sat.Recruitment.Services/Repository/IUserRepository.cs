using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Model;

namespace Sat.Recruitment.Services.Repository
{
    public interface IUserRepository
    {
        public abstract User insertUser(User user);
        public abstract User getUser(String email);
        public abstract List<User> getUsers();
        public abstract void Initialize();
    }
}
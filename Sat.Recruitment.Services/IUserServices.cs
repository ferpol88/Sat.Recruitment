using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.DTO;

namespace Sat.Recruitment.Services
{
    public interface IUserServices
    {
        public abstract User CreateUser(UserDTO user);
        public abstract User getUser(String email);

    }
}

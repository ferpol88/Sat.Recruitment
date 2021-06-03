using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Model.DTO;

namespace Sat.Recruitment.Model
{
    public interface IUserFactory
    {
        public User createUser(UserDTO user);
        public void Initialize();
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sat.Recruitment.Model.DTO;

namespace Sat.Recruitment.Model
    
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            this.CreateMap<User, UserDTO>();
        }
    }
}
